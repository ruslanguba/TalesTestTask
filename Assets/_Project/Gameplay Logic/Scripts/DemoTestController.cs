using System.Collections.Generic;
using UnityEngine;

public class DemoTestController : MonoBehaviour
{
    [SerializeField] private TrackableEntityBase[] _prefabs;
    [SerializeField] private EntitiesSpawner _spawner;
    [SerializeField] private EntitiesTracker _tracker;

    public void OnClickCreate()
    {
        if (_prefabs == null || _prefabs.Length == 0) return;

        int idx = Random.Range(0, _prefabs.Length);
        _spawner.SpawnAtRandomPosition(_prefabs[idx]);
    }

    public void OnClickDiactivate()
    {
        var list = _tracker.GetActive();
        var entity = PickRandom(list);
        if (entity != null)
            entity.gameObject.SetActive(false);
    }

    public void OnClickActivate()
    {
        var list = _tracker.GetInactive();
        var entity = PickRandom(list);
        if (entity != null)
            entity.gameObject.SetActive(true);
    }

    public void OnClickDestroy()
    {
        var list = _tracker.GetAll();
        var entity = PickRandom(list);
        if (entity != null)
            Destroy(entity.gameObject);
    }

    private TrackableEntityBase PickRandom(List<TrackableEntityBase> list)
    {
        if (list == null || list.Count == 0)
        {
            Debug.Log("No avaliable entity.");
            return null;
        }

        int idx = Random.Range(0, list.Count);
        return list[idx];
    }
}
