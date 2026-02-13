using UnityEngine;

public class Interactable : TrackableEntityBase
{
    protected override EntityType Type => EntityType.Interactable;
    [SerializeField] private float value = 6;
    public float Value => value;
}
