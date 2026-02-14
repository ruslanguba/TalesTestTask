using UnityEngine;

public abstract class TrackableEntityBase : MonoBehaviour
{
    [SerializeField] private EntitiesTracker _tracker;
    public abstract EntityType Type { get; }
    public abstract float Value { get; }
    public bool IsActive => isActiveAndEnabled;

    public void Initialize(EntitiesTracker tracker)
    {
        _tracker = tracker;
        _tracker?.Register(this);
        Debug.Log(Type + " spawned");
    }

    protected virtual void OnEnable()
    {
        _tracker?.SetActiveState(this, true);
        Debug.Log(Type + " is enable");
    }

    protected virtual void OnDisable()
    {
        _tracker?.SetActiveState(this, false);
        Debug.Log(Type + " is disable");
    }

    protected virtual void OnDestroy()
    {
        _tracker?.Unregister(this);
        Debug.Log(Type + " destroed");
    }
}
