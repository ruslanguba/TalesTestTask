using UnityEngine;

public class StoryActor : TrackableEntityBase
{
    public override EntityType Type => EntityType.StoryActor;
    [SerializeField] private float _value = 8;
    public override float Value => _value;
}
