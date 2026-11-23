# Components 기본 예제

`MovementTrackerSample`을 GameObject에 추가하고 Play Mode에서 Transform을 이동해 시작 이벤트를 확인합니다.

## Play Mode Scene

`MovementTrackerPlayModeSample.unity`를 열고 Play Mode를 실행합니다. 샘플 GameObject는 2초간
이동한 뒤 1초간 정지를 반복합니다. 화면에는 C# event와 `MovementTrackerUnityEventRelay`의
Inspector UnityEvent가 각각 받은 시작·진행·종료 횟수와 마지막 code delta를 표시합니다.

## Transform Follower

`TransformFollowerSample`을 열고 Play Mode에서 Scene 뷰나 Inspector로 위치를 확인합니다.
`Follower`는 시작 시 `Moving Target`의 X에 1을 더한 위치로 스냅하고, 이후 X 변화를 보간합니다.
대상의 Y가 움직여도 Follower의 월드 Y는 -2에 유지됩니다.
