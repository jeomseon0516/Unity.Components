# Jeomseon Unity Components

한국어 | [English](README.en.md)

MovementTracker가 Transform의 FixedUpdate 간 위치 차이를 관찰하고 이동 시작·지속·종료 이벤트를 제공합니다.

## 빠르게 시작하기

Tracker 추가 → MoveBegan/MoveOngoing/MoveEnded 구독 → 매 FixedUpdate에서 threshold 비교 → 수명 종료 전 구독 해제. Inspector 연결은 MovementTrackerUnityEventRelay를 사용합니다.

전체 샘플 코드: [MovementTrackerSample.cs](Samples~/BasicUsage/MovementTrackerSample.cs).

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

## 계약과 주의사항

이벤트 인자는 속도가 아닌 위치 delta입니다. threshold는 0.01~0.5로 제한됩니다. 이동을 제어하거나 Rigidbody 충돌을 계산하지 않으며, OnEnable마다 이전 위치를 재설정합니다.

## 요구 사항

- Unity `6000.6.0f1`
- 패키지: `com.jeomseon.unity.components` `0.3.1`

## 설치

프로젝트 `Packages/manifest.json`의 기존 dependencies와 registry를 유지하면서 다음 항목을 병합합니다.

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

또는 Package Manager의 **Install package from git URL**을 사용합니다:

```text
https://github.com/jeomseon0516/Unity.Components.git#v0.3.1
```

## API 사용과 상세 설명

### MovementTracker

코드에서는 C# event를 직접 구독합니다.

```csharp
tracker.MoveBegan += OnMoveBegan;
tracker.MoveOngoing += OnMoveOngoing;
tracker.MoveEnded += OnMoveEnded;
```

Inspector에서 이벤트를 연결하려면 같은 GameObject에 `MovementTrackerUnityEventRelay`를 추가합니다.
Relay는 Tracker의 event를 `On Move Began`, `On Move Ongoing`, `On Move Ended` UnityEvent로 전달합니다.

### Unity 기본 기능으로의 전환

다음 레거시 API는 제거했습니다.

- `MouseInputEvent`, `MouseLeftInputEvent`, `MouseRightInputEvent`, `MouseMovementTracker`:
  Input System의 `InputActionReference` 또는 `PlayerInput`을 사용하고 `started`/`performed`/
  `canceled` 콜백을 구독합니다.
- `TransformSmoothMover`, `Vector2SmoothMover`: 호출부에서 `Vector3.MoveTowards` 또는 `Vector3.Lerp`를
  시간 단위와 완료 계약에 맞춰 사용합니다.
- `DontDestroy`: 초기화 시 `Object.DontDestroyOnLoad(gameObject)`를 직접 호출합니다. Singleton이
  필요하면 `Jeomseon.Unity.Singleton` 패키지를 사용합니다.

## 샘플 실행

**Package Manager > Samples**에서 예제를 Import합니다. 포함된 Scene 또는 Editor 도구를 열고 필요한 Setup 메뉴를 먼저 실행합니다.

- [Basic Usage](Samples~/BasicUsage/README.md)
  - [MovementTrackerPlayModeSample](Samples~/BasicUsage/MovementTrackerPlayModeSample.unity)

## 추가 문서

[전체 코드 지도와 패키지 구성](Documentation~/Overview.md)
- [Changelog](CHANGELOG.md)

## 라이선스

[License](LICENSE.md)
