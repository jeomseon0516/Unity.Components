using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Jeomseon.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MovementTracker))]
    public sealed class MovementTrackerUnityEventRelay : MonoBehaviour
    {
        [SerializeField, FormerlySerializedAs("_onMoveBegan")] private UnityEvent<Vector3> onMoveBegan = new();
        [SerializeField, FormerlySerializedAs("_onMoveOngoing")] private UnityEvent<Vector3> onMoveOngoing = new();
        [SerializeField, FormerlySerializedAs("_onMoveEnded")] private UnityEvent<Vector3> onMoveEnded = new();

        private MovementTracker _movementTracker;

        private void Awake()
        {
            _movementTracker = GetComponent<MovementTracker>();
        }

        private void OnEnable()
        {
            _movementTracker.MoveBegan += onMoveBegan.Invoke;
            _movementTracker.MoveOngoing += onMoveOngoing.Invoke;
            _movementTracker.MoveEnded += onMoveEnded.Invoke;
        }

        private void OnDisable()
        {
            _movementTracker.MoveBegan -= onMoveBegan.Invoke;
            _movementTracker.MoveOngoing -= onMoveOngoing.Invoke;
            _movementTracker.MoveEnded -= onMoveEnded.Invoke;
        }
    }
}
