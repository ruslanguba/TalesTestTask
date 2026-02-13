# Task 1 – UI Refactoring

## Issues in the Original Implementation

The original code had several technical and logical issues:

- UI was updated inside `FixedUpdate` (physics loop)
- Incorrect average calculation
- Use of `GetComponents` instead of `GetComponent`
- Possible division by zero
- Unnecessary component lookups inside update loop
- UI updated every frame without need

---

## Improvements Made

- Moved logic from `FixedUpdate` to `Update`
- Added configurable update interval (default: 0.5 seconds)
- Corrected average value calculation
- Added protection against division by zero
- Removed unnecessary component lookups
- Replaced legacy `Text` with `TextMeshProUGUI`
- Count only active and enabled characters
- Kept the implementation simple and practical

---

## Design Decisions

- The list of characters is assigned via Inspector for clarity and explicit dependencies.
- UI is refreshed periodically instead of every frame to avoid unnecessary updates.
- No additional managers or architectural layers were introduced since the task scope focuses on UI refactoring and performance improvements.
- The solution prioritizes correctness, readability, and production-safe practices without overengineering.

---

## Optional Improvements (If Extended)

If characters were spawned dynamically or shared across multiple systems, the character list could be moved to a lightweight `CharactersTracker` class.

Such a tracker could:
- Centrally manage character registration/unregistration
- Automatically handle `OnEnable` / `OnDisable`
- Provide filtered access to active characters

This would further separate UI from data ownership and improve scalability for larger projects.

---