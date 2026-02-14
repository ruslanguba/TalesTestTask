using UnityEngine;

public class AverageCalculator : MonoBehaviour
{
    [SerializeField] protected EntitiesTracker _tracker;

    public float AvarageValue()
    {
        float avg = 0;

        foreach (TrackableEntityBase active in _tracker.GetActive())
        {
            avg += active.Value;
        }
        foreach(TrackableEntityBase active in _tracker.GetInactive())
        {
            avg += active.Value * 0.5f;
        }
        return avg / _tracker.TotalCount;
    }
}
