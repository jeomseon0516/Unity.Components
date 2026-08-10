# Jeomseon Unity Components

Provides `MovementTracker`, a component for observing Transform movement begin,
ongoing, and end events.

## MovementTracker

Subscribe to the C# events directly in code: `MoveBegan`, `MoveOngoing`, and
`MoveEnded`. To connect Inspector events, add `MovementTrackerUnityEventRelay`
to the same GameObject. The relay forwards those events to serialized UnityEvents.

## Migration to Unity APIs

- Replace the removed mouse input APIs with Input System `InputActionReference` or
  `PlayerInput` callbacks (`started`, `performed`, and `canceled`).
- Replace the removed smooth movers with `Vector3.MoveTowards` or `Vector3.Lerp`
  at the call site, using an explicit time and completion contract.
- Call `Object.DontDestroyOnLoad(gameObject)` directly, or use
  `Jeomseon.Unity.Singleton` when singleton ownership is required.
