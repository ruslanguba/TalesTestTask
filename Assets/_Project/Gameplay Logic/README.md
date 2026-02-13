# Task 3 – Gameplay Entity Tracking

## Overview

This task required implementing a simple and safe way to:

- Track gameplay entities (NPCs, interactables, story actors)
- Return only active entities
- Correctly handle:
  - Destroy()
  - SetActive(false)
  - Component disable

The solution avoids polling methods such as `FindObjectsOfType` and keeps the system lightweight and production-friendly.

---

## Structure

The system consists of:

- `ITrackableEntity` – defines the contract
- `TrackableEntityBase` – handles automatic registration
- `EntitiesTracker` – stores and returns active entities

---

## Approach

Each entity:

- Registers itself in `OnEnable`
- Unregisters itself in `OnDisable`
- Exposes an `IsActive` property

Unity guarantees that `OnDisable` is called before an object is destroyed, which ensures safe cleanup.

The tracker stores entities in a `HashSet` to:

- Prevent duplicate registration
- Provide fast add/remove operations

When active entities are requested, the tracker:

- Ignores null references
- Returns only entities where `IsActive` is true