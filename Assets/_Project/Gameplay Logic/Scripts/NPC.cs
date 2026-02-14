using UnityEngine;

public class NPC : TrackableEntityBase
{
    public override EntityType Type => EntityType.NPC;
    [SerializeField] private float _value = 2;
    public override float Value => _value;
}
