using System;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesTracker : MonoBehaviour
{
    public event Action StatsChanged;

    private readonly HashSet<TrackableEntityBase> _all = new();
    private readonly HashSet<TrackableEntityBase> _active = new();
    private readonly HashSet<TrackableEntityBase> _inactive = new();
    public int TotalCount => _all.Count;
    public int ActiveCount => _active.Count;
    public int InactiveCount => _inactive.Count;
    public List<TrackableEntityBase> GetAll() => new(_all);
    public List<TrackableEntityBase> GetActive() => new(_active);
    public List<TrackableEntityBase> GetInactive() => new(_inactive);

    public void Register(TrackableEntityBase entity)
    {
        if (entity == null) return;

        _all.Add(entity);
        SetActiveState(entity, entity.IsActive);
    }

    public void SetActiveState(TrackableEntityBase entity, bool isActive)
    {
        if (entity == null) return;

        if (isActive)
        {
            _active.Add(entity);
            _inactive.Remove(entity);
        }
        else
        {
            _inactive.Add(entity);
            _active.Remove(entity);
        }
        StatsChanged?.Invoke();
    }

    public void Unregister(TrackableEntityBase entity)
    {
        if (entity == null) return;

        _active.Remove(entity);
        _inactive.Remove(entity);
        _all.Remove(entity);
        StatsChanged?.Invoke();
    }
}
