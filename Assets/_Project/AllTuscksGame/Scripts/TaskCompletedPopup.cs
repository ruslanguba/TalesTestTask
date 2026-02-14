using UnityEngine;

public class TaskCompletedPopup : MonoBehaviour
{
    [SerializeField] private TaskSystem _task;
    [SerializeField] private PopupView _popup;

    private void OnEnable()
    {
        _task.Completed += Show;
    }

    private void OnDisable()
    {
        _task.Completed -= Show;
    }

    private void Show()
    {
        _popup.Show(
            "Completed!",
            $"Target reached:\nAvg: {_task.TargetAverage:0.0}",
            ("New Task", _task.NewTask)
        );
    }
}
