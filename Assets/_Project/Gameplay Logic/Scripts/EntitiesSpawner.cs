using UnityEngine;

public class EntitiesSpawner : MonoBehaviour
{
    [SerializeField] private EntitiesTracker _entitiesTracker;

    [SerializeField] private Vector2 _min = new Vector2(-8, -4);
    [SerializeField] private Vector2 _max = new Vector2(8, 4);
    [SerializeField] private Transform _parent;

    public TrackableEntityBase SpawnAtRandomPosition(TrackableEntityBase _entity)
    {
        TrackableEntityBase newEntity = Instantiate(_entity, GetRandomPosition(), Quaternion.identity, _parent);
        newEntity.Initialize(_entitiesTracker);
        return newEntity;
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(_min.x, _max.x);
        float y = Random.Range(_min.y, _max.y);

        return new Vector3(x, y, 0f);
    }
}
