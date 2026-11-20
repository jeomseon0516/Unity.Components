# Components 기본 예제

`MovementTrackerSample`을 GameObject에 추가하고 Play Mode에서 Transform을 이동해 시작 이벤트를 확인합니다.

## Play Mode Scene

`MovementTrackerPlayModeSample.unity`를 열고 Play Mode를 실행합니다. 샘플 GameObject는 2초간
이동한 뒤 1초간 정지를 반복합니다. 화면에는 C# event와 `MovementTrackerUnityEventRelay`의
Inspector UnityEvent가 각각 받은 시작·진행·종료 횟수와 마지막 code delta를 표시합니다.

## Transform Follower

URP 프로젝트에서 `TransformFollowerSample.unity`를 열고 Play Mode의 Game 뷰를 확인합니다.
파란 구는 `Moving Target`, 주황 큐브는 `Follower`입니다.

1. Hierarchy에서 `Follower`를 선택합니다. Transform Follower 컴포넌트의 **Target**은
   `Moving Target`, **Settings Asset**은 `SampleFollowSettings`를 가리킵니다.
2. Play Mode에서 기본 **X** 설정으로 Follower가 가로로 추적하고 월드 Y(-2)와 Z(0)를
   유지하는지 확인합니다. 시작할 때 X는 대상의 X에 오프셋을 더한 위치로 스냅합니다.
3. Play Mode에서 `Follower`의 **Runtime Settings**를 펼칩니다. **Axes**에 Y와 Z를 추가하거나
   **Offset**, **Smooth Time**을 바꿉니다. 변경은 현재 Follower에 즉시 적용됩니다. Smooth Time을 0으로 두면 다음 위치 갱신부터 보간 없이 따라갑니다.

**Asset Properties**는 공유 프리셋을 편집합니다. Follower는 시작 시 프리셋을 복사하므로
실행 중 프리셋을 편집해도 현재 추적에는 자동으로 반영되지 않습니다.
