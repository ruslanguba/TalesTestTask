using System;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesTracker : MonoBehaviour
{
    public event Action StatsChanged;

    private readonly HashSet<TrackableEntityBase> all = new();
    private readonly HashSet<TrackableEntityBase> active = new();
    private readonly HashSet<TrackableEntityBase> inactive = new();

    public int TotalCount => all.Count;
    public int ActiveCount => active.Count;
    public int InactiveCount => inactive.Count;
    public List<TrackableEntityBase> GetAll() => new(all);
    public List<TrackableEntityBase> GetActive() => new(active);
    public List<TrackableEntityBase> GetInactive() => new(inactive);

    public void Register(TrackableEntityBase entity)
    {
        if (entity == null) return;

        all.Add(entity);
        SetActiveState(entity, entity.IsActive);
        StatsChanged?.Invoke();
    }

    public void SetActiveState(TrackableEntityBase entity, bool isActive)
    {
        if (entity == null) return;

        if (isActive)
        {
            active.Add(entity);
            inactive.Remove(entity);
        }
        else
        {
            inactive.Add(entity);
            active.Remove(entity);
        }
        StatsChanged?.Invoke();
    }

    public void Unregister(TrackableEntityBase entity)
    {
        if (entity == null) return;

        active.Remove(entity);
        inactive.Remove(entity);
        all.Remove(entity);
        StatsChanged?.Invoke();
    }
}
