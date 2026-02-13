using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveCharactersSummaryView : MonoBehaviour
{
    [SerializeField] private List<Character> _characters;

    [SerializeField] private TextMeshProUGUI _activeCountText;
    [SerializeField] private TextMeshProUGUI _averageValueText;

    [SerializeField, Min(0.1f)] private float _updateInterval = 0.5f;

    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer < _updateInterval)
            return;

        _timer = 0f;
        Refresh();
    }

    private void Refresh()
    {
        int count = 0;
        float sum = 0f;

        foreach (var c in _characters)
        {
            if (c == null) continue;
            if (!c.gameObject.activeInHierarchy) continue;

            count++;
            sum += c.Value;
        }

        float avg = count > 0 ? sum / count : 0f;

        _activeCountText.text = count.ToString();
        _averageValueText.text = avg.ToString("0.0");
    }
}
