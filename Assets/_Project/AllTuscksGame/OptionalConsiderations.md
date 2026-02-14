# Optional Considerations

## How Would This Scale?

If entity count increased significantly:
- Replace full UI rebuild with diff-based updates.
- Introduce object pooling for UI items.
- Replace list allocations in tracker with read-only collections or iteration methods.
- Move calculation logic into a lightweight service class to decouple from MonoBehaviour.

---

## How Would a Designer Work With This?

Designers can:
- Adjust entity values directly in prefabs.
- Modify puzzle difficulty via `minCount`, `maxCount`, and tolerance in `TaskSystem`.
- Extend available entity types through `EntitiesCatalog` without modifying core logic.

The system is intentionally data-driven at the configuration level.