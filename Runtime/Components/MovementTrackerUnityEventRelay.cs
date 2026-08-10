using UnityEngine;
using UnityEngine.Events;

namespace Jeomseon.Components
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MovementTracker))]
    public sealed class MovementTrackerUnityEventRelay : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Vector3> _onMoveBegan = new();
        [SerializeField] private UnityEvent<Vector3> _onMoveOngoing = new();
        [SerializeField] private UnityEvent<Vector3> _onMoveEnded = new();

        private MovementTracker _movementTracker;

        private void Awake()
        {
            _movementTracker = GetComponent<MovementTracker>();
        }

        private void OnEnable()
        {
            _movementTracker.MoveBegan += _onMoveBegan.Invoke;
            _movementTracker.MoveOngoing += _onMoveOngoing.Invoke;
            _movementTracker.MoveEnded += _onMoveEnded.Invoke;
        }

        private void OnDisable()
        {
            _movementTracker.MoveBegan -= _onMoveBegan.Invoke;
            _movementTracker.MoveOngoing -= _onMoveOngoing.Invoke;
            _movementTracker.MoveEnded -= _onMoveEnded.Invoke;
        }
    }
}
