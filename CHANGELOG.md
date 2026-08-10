# 변경 기록

## [0.1.2] - 2026-07-29

- asmdef의 `rootNamespace`와 컴포넌트 파일 위치를 namespace에 맞게 정리했습니다.

## [0.1.1] - 2026-07-29

- MovementTracker 사용법을 확인하는 `Basic Usage` 샘플을 추가했습니다.

## [Unreleased]

### 변경

- `MovementTrackerPlayModeSample` Scene을 추가해 시작·진행·종료 event를 Play Mode에서
  확인할 수 있게 했습니다. C# event와 Inspector UnityEvent Relay의 호출 횟수를 함께 표시합니다.
- `MovementTracker`를 표준 C# event(`MoveBegan`, `MoveOngoing`, `MoveEnded`) 기반 계약으로
  정리하고, 선택적 `MovementTrackerUnityEventRelay`를 추가했습니다. Relay는 Inspector
  UnityEvent를 선호하는 사용자를 위해 별도로 부착합니다.
- **(Breaking)** 기존 `AddListenerOnMoveBegined`, `AddListenerOnMoveOnGoing`,
  `AddListenerOnMoveEnded` 및 대응 Remove/RemoveAll 메서드를 제거했습니다. C# event를
  `+=`/`-=`로 직접 구독합니다.
- **(Breaking)** `MouseInputEvent`, `MouseLeftInputEvent`, `MouseRightInputEvent`,
  `MouseMovementTracker`를 제거했습니다. Unity Input System의 `InputActionReference` 또는
  `PlayerInput` 콜백으로 대체합니다.
- **(Breaking)** `TransformSmoothMover`, `Vector2SmoothMover`, `IObjectSmoothMover`를
  제거했습니다. Unity `Vector3.MoveTowards` 또는 `Vector3.Lerp`를 호출부에서 사용합니다.
- **(Breaking)** `DontDestroy`를 제거했습니다. Unity `Object.DontDestroyOnLoad`를 직접
  호출하거나 Singleton 패키지를 사용합니다.
- 더 이상 사용하지 않는 Input System·Singleton 패키지 의존성과 SerializeReferenceDropdown 기반
  조건부 컴파일을 제거했습니다.

## [0.1.0] - 2026-07-29

- JeomseonScriptPack의 관련 모듈을 독립 UPM 패키지로 분리했습니다.


## [0.1.3] - 2026-08-05

- Unity 6000.5.7f1을 최소 지원 버전으로 상향했습니다.
