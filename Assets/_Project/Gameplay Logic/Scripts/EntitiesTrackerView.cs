using UnityEngine;
using TMPro;

public class EntitiesTrackerView : MonoBehaviour
{
    [SerializeField] private EntitiesTracker _tracker;
    [SerializeField] private TextMeshProUGUI _allEntities;
    [SerializeField] private TextMeshProUGUI _activeEntities;

    private void OnEnable()
    {
        _tracker.StatsChanged += UpdateUI;
        UpdateUI();
    }

    private void OnDisable()
    {
        _tracker.StatsChanged -= UpdateUI;
    }

    protected virtual void UpdateUI()
    {
        _allEntities.text = _tracker.TotalCount.ToString();
        _activeEntities.text = _tracker.ActiveCount.ToString();
    }
}
