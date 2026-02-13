using UnityEngine;

public class EntitiesSpawner : MonoBehaviour
{
    [SerializeField] private EntitiesTracker _entitiesTracker;

    [SerializeField] private Vector2 min = new Vector2(-8, -4);
    [SerializeField] private Vector2 max = new Vector2(8, 4);
    [SerializeField] private Transform _parent;

    public TrackableEntityBase SpawnEntity(TrackableEntityBase _entity)
    {
        TrackableEntityBase newEntity = Instantiate(_entity, GetRandomPosition(), Quaternion.identity, _parent);
        newEntity.Initialize(_entitiesTracker);
        return newEntity;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(min.x, max.x);
        float y = Random.Range(min.y, max.y);

        return new Vector3(x, y, 0f);
    }
}
