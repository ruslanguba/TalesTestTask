using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _bodyText;
    [SerializeField] private Button[] _buttons;
    private TextMeshProUGUI[] _buttonTexts;

    private void Awake()
    {
        // Cache buttons texts
        _buttonTexts = new TextMeshProUGUI[_buttons.Length];

        for (int i = 0; i < _buttons.Length; i++)
        {
            if (_buttons[i] != null)
                _buttonTexts[i] = _buttons[i].GetComponentInChildren<TextMeshProUGUI>();
        }
    }

    public void Show(string title, string body, params (string label, Action callback)[] buttons)
    {
        gameObject.SetActive(true);

        _titleText.text = title ?? string.Empty;
        _bodyText.text = body ?? string.Empty;

        int count = Mathf.Min(buttons.Length, _buttons.Length);

        for (int i = 0; i < _buttons.Length; i++)
        {
            if (i < count)
            {
                SetupButton(i, buttons[i].label, buttons[i].callback);
            }
            else
            {
                DisableButton(i);
            }
        }
    }

    private void SetupButton(int index, string label, Action callback)
    {
        var button = _buttons[index];
        button.gameObject.SetActive(true);

        if (_buttonTexts[index] != null)
            _buttonTexts[index].text = label;

        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(() =>
        {
            callback?.Invoke();
            Close();
        });
    }

    private void DisableButton(int index)
    {
        var button = _buttons[index];
        button.onClick.RemoveAllListeners();
        button.gameObject.SetActive(false);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
