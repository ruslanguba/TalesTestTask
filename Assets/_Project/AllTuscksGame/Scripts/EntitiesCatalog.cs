using System.Collections.Generic;
using UnityEngine;

public class EntitiesCatalog : MonoBehaviour
{
    [SerializeField] private NPC _npcPrefab;
    [SerializeField] private Interactable _interactablePrefab;
    [SerializeField] private StoryActor _storyActorPrefab;

    public TrackableEntityBase GetPrefab(EntityType type) => type switch
    {
        EntityType.NPC => _npcPrefab,
        EntityType.Interactable => _interactablePrefab,
        EntityType.StoryActor => _storyActorPrefab,
        _ => null
    };

    public void GetAllPrefabs(List<TrackableEntityBase> buffer)
    {
        buffer.Clear();
        buffer.Add(_npcPrefab);
        buffer.Add(_interactablePrefab);
        buffer.Add(_storyActorPrefab);
    }
}
