using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScrollburSetToUpPos : MonoBehaviour
{
    private ScrollRect _scrollRect;

    private void Awake()
    {
        _scrollRect = GetComponent<ScrollRect>();
    }

    private void OnEnable()
    {
        StartCoroutine(ResetNextFrame());
    }

    private IEnumerator ResetNextFrame()
    {
        yield return null;

        Canvas.ForceUpdateCanvases();

        _scrollRect.verticalNormalizedPosition = 1f;
    }
}
