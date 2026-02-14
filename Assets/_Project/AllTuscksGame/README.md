# Entity Average Puzzle

Small Unity puzzle prototype.

## 🎯 Goal

Create entities and adjust their active/inactive state to match:

- Target average value
- Allowed entity count range

Active entities contribute 100% of their value.  
Inactive entities contribute 50%.

---

## 🧩 Gameplay Rules

- Each entity has a base value:
  - NPC = 2
  - Interactable = 6
  - StoryActor = 8
- Effective value:
  - Active → full value
  - Inactive → half value
- The puzzle is completed when:
  - Total entity count is within allowed range
  - Current average matches target average (with small tolerance)

---

## 🏗 Architecture Overview

### Core Systems
- `EntitiesTracker` — tracks all entities and their active state
- `AverageCalculator` — calculates effective average value
- `TaskSystem` — generates tasks and validates completion
- `PopupView` — reusable popup UI system

### UI
- `SummaryView` — displays current stats
- `TaskView` — displays current target
- `UIEntitiesList` — shows entity list
- `TaskCompletedPopup` — shows completion popup

---

## 🧠 Design Decisions

- Logic and UI are separated via events.
- Tasks are generated from valid combinations, ensuring solvability.
- Entities are tracked safely via register/unregister system.
- Minimal architecture, no external libraries.

---

## 🚀 How To Play

1. Create entities.
2. Activate/Deactivate them.
3. Adjust count and average.
4. When conditions are met — puzzle completes.

---

Unity Version: 6.x  
No external packages required.