using NUnit.Framework.Internal;
using System;
using UnityEngine;

public class PopupDemoTest : MonoBehaviour
{
    [SerializeField] private PopupView popup;

    private void Start()
    {
        ShowInfo(); // чтобы сразу было видно при запуске
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) ShowInfo();
        if (Input.GetKeyDown(KeyCode.Alpha2)) ShowConfirm();
        if (Input.GetKeyDown(KeyCode.Alpha3)) ShowChoice();
        if (Input.GetKeyDown(KeyCode.Alpha4)) ShowLongText();
        if (Input.GetKeyDown(KeyCode.Escape)) popup.Close();
    }

    private void ShowInfo()
    {
        popup.Show(
            "Info",
            "This is a simple one-button popup.\n\nPress 2, 3 or 4 to test other cases.",
            ("OK", null)
        );
    }

    private void ShowConfirm()
    {
        popup.Show(
            "Exit Game",
            "Are you sure you want to quit?\n\n(Example confirm popup)",
            ("Yes", () => Debug.Log("Quit confirmed (demo).")),
            ("No", null)
        );
    }

    private void ShowChoice()
    {
        popup.Show(
            "Change Difficulty",
            "Choose Difficulty",
            ("Easy", () => Debug.Log("Difficulty: Easy")),
            ("Normal", () => Debug.Log("Difficulty: Normal")),
            ("Hard", () => Debug.Log("Difficulty: Hard"))
        );
    }

    private void ShowLongText()
    {
        popup.Show(
        "This is a long body text to test ScrollRect.",
        LongText(),
        ("OK", null)
        );

    }

    private string LongText()
    {
        return
        @"Scroll down to see more...
        Line 1: Lorem ipsum dolor sit amet.
        Line 2: Consectetur adipiscing elit.
        Line 3: Sed do eiusmod tempor incididunt.
        Line 4: Ut labore et dolore magna aliqua.
        Line 5: Ut enim ad minim veniam.
        Line 6: Quis nostrud exercitation ullamco.
        Line 7: Laboris nisi ut aliquip ex ea commodo.
        Line 8: Duis aute irure dolor in reprehenderit.
        Line 9: Excepteur sint occaecat cupidatat non proident.
        Line 10: Sunt in culpa qui officia deserunt mollit.

        Scroll down to see more...

        End.";
    }
}
