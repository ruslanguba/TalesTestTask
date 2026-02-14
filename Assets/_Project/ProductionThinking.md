# Production Thinking – Technical Overview

## Technical Test Implementation

In this technical test, I independently implemented a system for tracking gameplay entities and validating puzzle conditions with a clear separation between logic and UI.

The main challenge was handling dynamic scene changes — object creation, destruction, and activation state changes — without breaking data consistency or introducing tight coupling between systems.

To solve this, I designed a centralized `EntitiesTracker` that registers entities through Unity’s lifecycle methods (`OnEnable`, `OnDisable`, `OnDestroy`) and uses an event-driven approach to notify dependent systems. The puzzle validation logic (`TaskSystem`) was fully decoupled from the UI layer, ensuring modularity and easier extensibility.  

This approach allowed the system to remain stable under frequent state changes while maintaining clean architectural boundaries.

---

## Platformer Project – Character Architecture

In a separate 2D platformer project, I independently designed the character control architecture with a focus on scalability and maintainability.

The primary challenge was avoiding monolithic MonoBehaviour classes and tightly coupled logic as mechanics grew in complexity.

I introduced a `CharacterContext` to centralize dependencies, applied behavior abstraction via interfaces, and implemented a finite state machine to manage character states. Input handling, movement logic, and state transitions were separated into dedicated components.

This architecture allowed new mechanics to be added without modifying core systems, supporting long-term extensibility and clean code structure.

---

## Key Production Principles Applied

- Separation of logic and presentation
- Event-driven communication between systems
- Centralized dependency management
- Lifecycle-safe entity tracking
- Scalable and modular architecture design