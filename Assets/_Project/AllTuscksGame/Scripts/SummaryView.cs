using TMPro;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SummaryView : MonoBehaviour
{
    [SerializeField] private AverageCalculator _calculator;
    [SerializeField] private EntitiesTracker _entitiesTracker;

    [SerializeField] private TextMeshProUGUI _totalCountText;
    [SerializeField] private TextMeshProUGUI _activeCountText;
    [SerializeField] private TextMeshProUGUI _averageValueText;

    private void OnEnable()
    {
        _entitiesTracker.StatsChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        _entitiesTracker.StatsChanged -= Refresh;
    }

    private void Refresh()
    {
        _totalCountText.text = _entitiesTracker.TotalCount.ToString();    
        _activeCountText.text = _entitiesTracker.ActiveCount.ToString();
        if (_entitiesTracker.TotalCount > 0)
            _averageValueText.text = _calculator.AvarageValue().ToString("0.0");
        else
            _averageValueText.text = "0,0";
    }
}
