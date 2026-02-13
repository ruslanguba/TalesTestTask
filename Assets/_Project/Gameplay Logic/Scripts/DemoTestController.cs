using System.Collections.Generic;
using UnityEngine;

public class DemoTestController : MonoBehaviour
{
    [SerializeField] private TrackableEntityBase[] prefabs;
    [SerializeField] private EntitiesSpawner spawner;
    [SerializeField] private EntitiesTracker tracker;

    public void OnClickCreate()
    {
        if (prefabs == null || prefabs.Length == 0) return;

        int idx = Random.Range(0, prefabs.Length);
        spawner.SpawnEntity(prefabs[idx]);
    }

    public void OnClickDiactivate()
    {
        var list = tracker.GetActive();
        var entity = PickRandom(list);
        if (entity != null)
            entity.gameObject.SetActive(false);
    }

    public void OnClickActivate()
    {
        var list = tracker.GetInactive();
        var entity = PickRandom(list);
        if (entity != null)
            entity.gameObject.SetActive(true);
    }

    public void OnClickDestroy()
    {
        var list = tracker.GetAll();
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
