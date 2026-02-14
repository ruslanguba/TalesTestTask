using TMPro;
using UnityEngine;

public class TaskView : MonoBehaviour
{
    [SerializeField] private TaskSystem _task;

    [SerializeField] private TextMeshProUGUI _minCountText;
    [SerializeField] private TextMeshProUGUI _maxCountText;
    [SerializeField] private TextMeshProUGUI _targetAvgText;

    private void OnEnable()
    {
        _task.TaskChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        _task.TaskChanged -= Refresh;
    }

    private void Refresh()
    {
        _minCountText.text = _task.MinCount.ToString();
        _maxCountText.text = _task.MaxCount.ToString();
        _targetAvgText.text = _task.TargetAverage.ToString("0.0");
    }
}
