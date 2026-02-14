using UnityEngine;

public class Interactable : TrackableEntityBase
{
    public override EntityType Type => EntityType.Interactable;
    [SerializeField] private float _value = 6;
    public override float Value => _value;
}
