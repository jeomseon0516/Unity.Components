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
3. Play Mode를 종료합니다. **Settings Asset**에 표시된 `SampleFollowSettings`를 더블클릭한 뒤
   자산 Inspector의 **Axes**에 **Y**와 **Z**를 추가하고 다시 실행합니다. 각 오브젝트의 Transform에서 세 좌표가
   추적되는 것을 확인합니다.
4. Play Mode를 종료한 뒤 **Offset**이나 **Smooth Time**을 바꿔 다시 실행합니다.
   Smooth Time이 0이면 선택 축의 위치가 즉시 갱신되고, 양수이면 보간합니다.

Follower는 초기화 시 프리셋 값을 복사합니다. 실행 중 자산 편집은 이미 초기화된 Follower의
값을 갱신하지 않으며, 자산 편집은 세션 종료 후에도 저장될 수 있습니다.
