# Jeomseon Unity Components

[한국어](README.md) | English

MovementTracker observes Transform displacement between FixedUpdates and emits movement start/ongoing/end events.

## Quick start

Attach a Tracker, subscribe to MoveBegan/MoveOngoing/MoveEnded, compare displacement each FixedUpdate, and unsubscribe on shutdown. Use MovementTrackerUnityEventRelay for Inspector responses.

Complete sample: [MovementTrackerSample.cs](Samples~/BasicUsage/MovementTrackerSample.cs).

```csharp
using Jeomseon.Unity.Components;
using UnityEngine;

namespace Jeomseon.Samples.Components
{
    [RequireComponent(typeof(MovementTracker))]
    public sealed class MovementTrackerSample : MonoBehaviour
    {
        private MovementTracker _movementTracker;

        private void Awake()
        {
            _movementTracker = GetComponent<MovementTracker>();
        }

        private void OnEnable()
        {
            _movementTracker.MoveBegan += OnMoveBegan;
        }

        private void OnDisable()
        {
            _movementTracker.MoveBegan -= OnMoveBegan;
        }

        private static void OnMoveBegan(Vector3 delta)
        {
            Debug.Log($"이동 시작: {delta}");
        }
    }
}
```

## Contracts and limitations

Payloads are position deltas, not velocity. Threshold is clamped to 0.01–0.5. It does not control movement or simulate collisions; OnEnable resets the previous position.

## Requirements

- Unity `6000.6.0f1`
- Package: `com.jeomseon.unity.components` `0.3.1`

## Installation

Merge this into your project's `Packages/manifest.json`; preserve existing dependencies and registries.

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

Or use **Install package from git URL** in Package Manager:

```text
https://github.com/jeomseon0516/Unity.Components.git#v0.3.1
```

## API usage and details

### MovementTracker

Subscribe to the C# events directly in code: `MoveBegan`, `MoveOngoing`, and
`MoveEnded`. To connect Inspector events, add `MovementTrackerUnityEventRelay`
to the same GameObject. The relay forwards those events to serialized UnityEvents.

### Migration to Unity APIs

- Replace the removed mouse input APIs with Input System `InputActionReference` or
  `PlayerInput` callbacks (`started`, `performed`, and `canceled`).
- Replace the removed smooth movers with `Vector3.MoveTowards` or `Vector3.Lerp`
  at the call site, using an explicit time and completion contract.
- Call `Object.DontDestroyOnLoad(gameObject)` directly, or use
  `Jeomseon.Unity.Singleton` when singleton ownership is required.

## Samples

Import the desired entry from **Package Manager > Samples**. Use the included Scene/Editor tool and complete its Setup step first, if required.

- [Basic Usage](Samples~/BasicUsage/README.md)
  - [MovementTrackerPlayModeSample](Samples~/BasicUsage/MovementTrackerPlayModeSample.unity)

## Further reading

[Complete source map and package metadata](Documentation~/Overview.en.md)
- [Changelog](CHANGELOG.md)

## License

[License](LICENSE.md)
