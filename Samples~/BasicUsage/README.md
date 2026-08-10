# Components 기본 예제

`MovementTrackerSample`을 GameObject에 추가하고 Play Mode에서 Transform을 이동해 시작 이벤트를 확인합니다.

## Play Mode Scene

`MovementTrackerPlayModeSample.unity`를 열고 Play Mode를 실행합니다. 샘플 GameObject는 2초간
이동한 뒤 1초간 정지를 반복합니다. 화면에는 C# event와 `MovementTrackerUnityEventRelay`의
Inspector UnityEvent가 각각 받은 시작·진행·종료 횟수와 마지막 code delta를 표시합니다.
