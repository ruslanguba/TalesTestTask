using System;
using System.Collections.Generic;
using UnityEngine;

public class TaskSystem : MonoBehaviour
{
    public event Action TaskChanged;
    public event Action Completed;

    [Header("Core")]
    [SerializeField] private EntitiesTracker _tracker;
    [SerializeField] private AverageCalculator _average;
    [SerializeField] private EntitiesCatalog _catalog;

    [Header("Task Settings")]
    [SerializeField, Min(1)] private int _minCount = 3;
    [SerializeField, Min(1)] private int _maxCount = 10;
    [SerializeField] private float _tolerance = 0.05f;

    public int MinCount { get; private set; }
    public int MaxCount { get; private set; }
    public float TargetAverage { get; private set; }

    private bool _completedRaised;

    private readonly List<TrackableEntityBase> _prefabs = new();
    private readonly List<float> _effValues = new();

    private void Awake()
    {
        BuildEffectiveValues();
    }

    private void OnEnable()
    {
        _tracker.StatsChanged += CheckCompletion;
    }

    private void OnDisable()
    {
        _tracker.StatsChanged -= CheckCompletion;
    }

    private void Start()
    {
        NewTask();
        CheckCompletion();
    }

    public void NewTask()
    {
        _completedRaised = false;

        MinCount = _minCount;
        MaxCount = UnityEngine.Random.Range(_minCount, _maxCount + 1);

        int solutionCount = UnityEngine.Random.Range(_minCount, MaxCount + 1);

        float sum = 0f;
        for (int i = 0; i < solutionCount; i++)
            sum += _effValues[UnityEngine.Random.Range(0, _effValues.Count)];

        TargetAverage = sum / solutionCount;

        TaskChanged?.Invoke();
    }

    private void BuildEffectiveValues()
    {
        _effValues.Clear();
        _catalog.GetAllPrefabs(_prefabs);

        for (int i = 0; i < _prefabs.Count; i++)
        {
            float v = _prefabs[i].Value;
            _effValues.Add(v);        // _active
            _effValues.Add(v * 0.5f); // _inactive
        }
    }

    private void CheckCompletion()
    {
        if (_completedRaised) return;

        int count = _tracker.TotalCount;
        if (count > MaxCount) return;

        if (count < _minCount) return;

        float currentAvg = _average.AvarageValue();
        if (Mathf.Abs(currentAvg - TargetAverage) > _tolerance) return;

        _completedRaised = true;
        Completed?.Invoke();
    }
}
