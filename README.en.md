# Jeomseon Unity Components

Provides `MovementTracker`, a component for observing Transform movement begin,
ongoing, and end events.

## Install via OpenUPM

Register the OpenUPM scoped registry once in your project's `Packages/manifest.json`.

```json
{
  "scopedRegistries": [
    {
      "name": "OpenUPM",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.jeomseon"
      ]
    }
  ],
  "dependencies": {
    "com.jeomseon.unity.components": "0.3.1"
  }
}
```

## Install via Git URL

Enter the following URL in Unity Package Manager's `Install package from git URL`.

```text
https://github.com/jeomseon0516/Unity.Components.git#v0.3.1
```

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
