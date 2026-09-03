# Jeomseon Unity Components

Transform 이동 시작·진행·종료를 관찰하는 `MovementTracker` 컴포넌트를 제공합니다.

## MovementTracker

코드에서는 C# event를 직접 구독합니다.

```csharp
tracker.MoveBegan += OnMoveBegan;
tracker.MoveOngoing += OnMoveOngoing;
tracker.MoveEnded += OnMoveEnded;
```

Inspector에서 이벤트를 연결하려면 같은 GameObject에 `MovementTrackerUnityEventRelay`를 추가합니다.
Relay는 Tracker의 event를 `On Move Began`, `On Move Ongoing`, `On Move Ended` UnityEvent로 전달합니다.

## OpenUPM으로 설치

프로젝트의 `Packages/manifest.json`에 OpenUPM scoped registry를 한 번 등록합니다.

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

## Git URL로 설치

Unity Package Manager의 `Install package from git URL`에 다음 주소를 사용합니다.

```text
https://github.com/jeomseon0516/Unity.Components.git#v0.3.1
```

## Unity 기본 기능으로의 전환

다음 레거시 API는 제거했습니다.

- `MouseInputEvent`, `MouseLeftInputEvent`, `MouseRightInputEvent`, `MouseMovementTracker`:
  Input System의 `InputActionReference` 또는 `PlayerInput`을 사용하고 `started`/`performed`/
  `canceled` 콜백을 구독합니다.
- `TransformSmoothMover`, `Vector2SmoothMover`: 호출부에서 `Vector3.MoveTowards` 또는 `Vector3.Lerp`를
  시간 단위와 완료 계약에 맞춰 사용합니다.
- `DontDestroy`: 초기화 시 `Object.DontDestroyOnLoad(gameObject)`를 직접 호출합니다. Singleton이
  필요하면 `Jeomseon.Unity.Singleton` 패키지를 사용합니다.
