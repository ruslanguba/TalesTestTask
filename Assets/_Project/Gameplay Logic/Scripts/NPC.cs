using UnityEngine;

public class NPC : TrackableEntityBase
{
    protected override EntityType Type => EntityType.NPC;
    [SerializeField] private float value = 2;
    public float Value => value;
}
