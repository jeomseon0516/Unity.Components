# Components 로드맵

우선순위: `P0` 결함·안전성 → `P1` 핵심 구조 → `P2` API·성능 → `P3` 장기 확장

## 작업 순서

1. **P0-01 — 입력 이벤트 인덱스 처리 검증 (완료)**
   - 첫 번째 이벤트 중복 생성 결함이 있는 자체 입력 계층을 수정 대신 제거하고 Input System
     `InputAction` 콜백으로 대체했습니다.
2. **P1-01 — Input System 기반 입력 구조로 전환 (완료)**
   - 자체 polling wrapper는 추가 가치를 제공하지 않아 제거했습니다.
3. **P1-02 — SerializeReference 의존성 정리 (완료)**
   - 선택적 SerializeReferenceDropdown define과 해당 공개 API를 제거했습니다.
4. **P2-01 — Movement 컴포넌트 계약 통합 (완료)**
   - 시간·완료 계약이 불명확한 Transform·Vector smooth mover를 제거하고 Unity 기본 이동 API로
     대체했습니다. `MovementTracker`는 Transform 이동 관찰이라는 별도 계약으로 유지합니다.
   - SmoothMover는 Inspector UnityEvent 기반 시작·완료·취소 계약의 실제 사용 목적이 있어,
     DOTween 직접 의존성 없이 재도입 가능성을 보류합니다. 제품 요구가 생기면 Unity 기본 API와
     DOTween 선택적 통합을 비교한 뒤 독립 계약으로 설계합니다.
5. **P3-01 — MonoBehaviour 기능의 조립형 구성 (완료)**
   - `MovementTracker`는 C# event로 관찰 계약만 제공하고, Inspector UnityEvent가 필요한 경우에만
     `MovementTrackerUnityEventRelay`를 조립합니다. 위치 원본·판정 정책 분리는 실제 요구가
     생길 때만 검토합니다.

### TransformFollower

- `TransformFollower`는 선택 축을 월드 좌표에서 추적합니다. `Initialize`는 즉시 스냅하고 이후 LateUpdate에서 오프셋과 보간을 적용합니다.
- `FollowSettings(FollowAxes, in Vector3, float)`의 보간 시간은 유한한 0 이상이어야 합니다. 0이면 즉시 이동합니다.
- `SetTarget`은 보간 속도를 초기화하며, `snap: false`는 다음 LateUpdate부터 추적을 시작합니다. 대상이 없거나 파괴되면 위치 갱신을 멈춥니다.
- `SetSettings`는 선택 여부가 바뀐 축의 속도를 초기화합니다. 양수 보간 시간만 바꾸면 현재 속도를 이어가며, 보간에는 최대 속도 제한을 두지 않습니다.
- Basic Usage의 `TransformFollowerSample`의 URP Game 뷰와 기본 Inspector에서 초기 스냅, 축 고정,
  오프셋과 보간을 확인합니다.

#### Inspector 설정 자산 제안

- 공유 프리셋은 `ScriptableObject`에 `FollowAxes`, `Vector3` 오프셋 및 0 이상의 보간 시간을
  직렬화합니다. 씬의 `TransformFollower`는 대상 `Transform`과 프리셋을 참조하고, 초기화할 때
  기존 `FollowSettings` 값으로 복사합니다.
- 두 참조를 갖춘 컴포넌트만 씬 설정으로 한 번 초기화합니다. 참조가 비어 있으면 자동 초기화하지
  않으며, 런타임 `Initialize` 호출이 이미 설정한 상태를 덮어쓰지 않습니다.
- Play Mode에서 코드는 `SetSettings`와 `SetTarget`으로 인스턴스를 변경합니다. 공유 프리셋의
  Inspector 편집은 다음 초기화부터 적용하는 계약을 검토합니다.
