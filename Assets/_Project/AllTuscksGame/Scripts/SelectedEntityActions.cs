using UnityEngine;

public class SelectedEntityActions : MonoBehaviour
{
    [SerializeField] private SelectedEntity _selection;

    public void DestroySelected()
    {
        if (_selection.Current == null) return;
        var go = _selection.Current.gameObject;
        _selection.Clear();
        Destroy(go);
    }

    public void ActivateSelected()
    {
        if (_selection.Current == null) return;
        _selection.Current.gameObject.SetActive(true);
    }

    public void DeactivateSelected()
    {
        if (_selection.Current == null) return;
        _selection.Current.gameObject.SetActive(false);
    }
}
