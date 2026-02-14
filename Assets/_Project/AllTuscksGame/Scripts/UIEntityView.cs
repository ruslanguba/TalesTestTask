using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEntityView : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _valueText;
    [SerializeField] private GameObject _selectedHighlight;

    [Header("Colors")]
    [SerializeField] private Color _activeColor;
    [SerializeField] private Color _inactiveColor;


    private TrackableEntityBase _entity;
    private SelectedEntity _selection;

    public void Bind(TrackableEntityBase entity, SelectedEntity selection)
    {
        _entity = entity;
        _selection = selection;

        _button.onClick.RemoveAllListeners();
        _button.onClick.AddListener(() =>
        {
            if (_entity != null)
                _selection.Set(_entity);
        });

        Refresh();
        RefreshSelected();
    }

    public void Refresh()
    {
        if (_entity == null)
        {
            _nameText.text = "<missing>";
            _valueText.text = "";
            return;
        }

        bool isActive = _entity.IsActive;
        float effective = _entity.IsActive ? _entity.Value : _entity.Value * 0.5f;

        Color stateColor = isActive ? _activeColor : _inactiveColor;
        stateColor.a = 1;
        _image.color = stateColor;

        _nameText.text = _entity.Type.ToString();
        _valueText.text = effective.ToString();
    }

    public void RefreshSelected()
    {
        if (_selectedHighlight == null) return;
        _selectedHighlight.SetActive(_selection != null && _selection.Current == _entity);
    }
}
