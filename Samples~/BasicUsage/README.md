# Components 기본 예제

`MovementTrackerSample`을 GameObject에 추가하고 Play Mode에서 Transform을 이동해 시작 이벤트를 확인합니다.

## Play Mode Scene

`MovementTrackerPlayModeSample.unity`를 열고 Play Mode를 실행합니다. 샘플 GameObject는 2초간
이동한 뒤 1초간 정지를 반복합니다. 화면에는 C# event와 `MovementTrackerUnityEventRelay`의
Inspector UnityEvent가 각각 받은 시작·진행·종료 횟수와 마지막 code delta를 표시합니다.

## Transform Follower

URP 프로젝트에서 `TransformFollowerSample.unity`를 열고 Play Mode의 Game 뷰를 확인합니다.
파란 구는 `Moving Target`, 주황 큐브는 `Follower`입니다.

1. Hierarchy에서 `Moving Target`을 선택하고 Inspector의 **Follow Settings**를 확인합니다.
2. **Axes** 기본값인 **X**에서는 Follower가 가로로 움직이고 월드 Y(-2)와 Z(0)는 고정됩니다.
3. **Axes**에 **Y**와 **Z**를 차례로 켭니다. 세 축을 움직이는 대상에 맞춰 Follower가 선택한
   축을 따라갑니다. 정확한 좌표는 각 오브젝트의 Transform을 비교합니다.
4. **Offset**을 바꾸면 선택한 축의 목표 위치가 달라집니다. **Smooth Time**을 0으로 두면
   다음 위치 갱신부터 즉시 따라가며, 양수에서는 보간합니다.

Play Mode에서 바꾼 값은 샘플의 Follower 한 개에 적용됩니다. 초기화할 때는 선택한 축을
대상 위치와 Offset에 맞춰 스냅합니다.
