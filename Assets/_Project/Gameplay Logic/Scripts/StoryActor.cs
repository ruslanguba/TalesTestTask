using UnityEngine;

public class StoryActor : TrackableEntityBase
{
    protected override EntityType Type => EntityType.StoryActor;
    [SerializeField] private float value = 8;
    public float Value => value;
}
