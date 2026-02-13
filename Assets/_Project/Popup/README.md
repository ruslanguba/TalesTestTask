# Task 2 – Popup System

## Overview

Implemented a reusable popup system that supports:

- Title
- Scrollable body text
- 1–3 buttons
- Per-button callbacks

The solution is simple, modular, and uses standard Unity UI components.

---

## UI Structure

PopupRoot (inactive by default)
 └── PopupWindow
      ├── TitleText (TMP)
      ├── BodyArea
      │    └── ScrollRect
      │         ├── Viewport (RectMask2D)
      │         │     └── BodyText (TMP)
      │         └── Scrollbar Vertical
      └── ButtonsRow (1–3 Buttons)

---

## Implementation Highlights

- Uses `params (string label, Action callback)[]` for clean API.
- Buttons are dynamically enabled/disabled.
- Button texts are cached in `Awake()` to avoid repeated lookups.
- Scroll position resets to top when popup is shown.
- PopupRoot is inactive by default and activated via `Show()`.

---

## Example Usage

```csharp
popup.Show(
    "Exit Game",
    "Are you sure you want to quit?",
    ("Yes", () => Application.Quit()),
    ("No", null)
);

## Design Decisions

No external libraries.

No managers or event buses.

No ScriptableObjects (not required by task).

Focus on clarity and practical usage.

## Optional Improvements

Store popup definitions in ScriptableObjects.

Add animation transitions.

Implement popup stacking or queue system.