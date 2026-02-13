using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ScrollburSetToUpPos : MonoBehaviour
{
    private Scrollbar _scroller;

    private void Awake()
    {
        _scroller = GetComponent<Scrollbar>();
    }

    private void OnEnable()
    {
        _scroller.value = 1;
    }

}
