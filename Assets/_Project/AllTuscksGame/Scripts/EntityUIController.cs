using UnityEngine;

public class EntityUIController : MonoBehaviour
{
    [Header("Core")]
    [SerializeField] private PopupView _popup;
    [SerializeField] private EntitiesSpawner _spawner;
    [SerializeField] private EntitiesCatalog _catalog;
    [SerializeField] private SelectedEntity _selection;
    [SerializeField] private SelectedEntityActions _actions;

    private void Awake()
    {
        ShowTutorial();
    }

    public void OnClickCreate()
    {
        _popup.Show(
            "Create",
            "Choose entity type:",
            ("NPC (2)", () => Spawn(EntityType.NPC)),
            ("Interactable (6)", () => Spawn(EntityType.Interactable)),
            ("StoryActor (8)", () => Spawn(EntityType.StoryActor))
        );
    }

    private void Spawn(EntityType type)
    {
        var prefab = _catalog.GetPrefab(type);
        if (prefab == null)
        {
            Debug.LogWarning($"No prefab for {type}");
            return;
        }
        _spawner.SpawnAtRandomPosition(prefab);
    }

    public void OnClickDelete()
    {
        if (_selection.Current == null)
        {
            _popup.Show("Delete", "No entity selected.", ("OK", null));
            return;
        }

        _popup.Show(
            "Delete",
            $"Delete selected?\n{_selection.Current.name}",
            ("Delete", _actions.DestroySelected),
            ("Cancel", null)
        );
    }

    public void OnClickActivate()
    {
        if (_selection.Current == null)
        {
            _popup.Show("Activate", "No entity selected.", ("OK", null));
            return;
        }

        _actions.ActivateSelected();
    }

    public void OnClickDeactivate()
    {
        if (_selection.Current == null)
        {
            _popup.Show("Deactivate", "No entity selected.", ("OK", null));
            return;
        }

        _actions.DeactivateSelected();
    }

    private void ShowTutorial()
    {
        _popup.Show(
            "Welcome!",
            "Goal:\n\n" +
            "Create entities and adjust their states to match the target average.\n\n" +
            "Active entities give 100% value.\n" +
            "Inactive entities give 50% value.\n\n" +
            "Keep total count within allowed range.",
            ("Start", null)
        );
    }
}
