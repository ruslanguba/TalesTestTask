using System;
using UnityEngine;

public class SelectedEntity : MonoBehaviour
{
    public event Action Changed;
    public TrackableEntityBase Current { get; private set; }

    public void Set(TrackableEntityBase entity)
    {
        if (Current == entity) return;
        Current = entity;
        Changed?.Invoke();
    }

    public void Clear() => Set(null);
}
