using System.Collections.Generic;
using UnityEngine;

public class UIEntitiesList : MonoBehaviour
{
    [SerializeField] private EntitiesTracker _tracker;
    [SerializeField] private SelectedEntity _selection;

    [SerializeField] private UIEntityView _itemPrefab;
    [SerializeField] private Transform _container; // Content with LayoutGroup

    private readonly List<UIEntityView> _items = new();

    private void OnEnable()
    {
        _tracker.StatsChanged += Rebuild;
        _selection.Changed += RefreshVisuals;

        Rebuild();
    }

    private void OnDisable()
    {
        _tracker.StatsChanged -= Rebuild;
        _selection.Changed -= RefreshVisuals;
    }

    private void Rebuild()
    {
        var entities = _tracker.GetAll();

        // если выбранный объект исчез из трекера Ч сброс
        if (_selection.Current != null && !entities.Contains(_selection.Current))
            _selection.Clear();

        for (int i = 0; i < _items.Count; i++)
            if (_items[i] != null) Destroy(_items[i].gameObject);

        _items.Clear();

        foreach (var e in entities)
        {
            if (e == null) continue;

            var item = Instantiate(_itemPrefab, _container);
            item.Bind(e, _selection);
            _items.Add(item);
        }

        RefreshVisuals();
    }

    private void RefreshVisuals()
    {
        for (int i = 0; i < _items.Count; i++)
        {
            if (_items[i] == null) continue;
            _items[i].Refresh();
            _items[i].RefreshSelected();
        }
    }
}
