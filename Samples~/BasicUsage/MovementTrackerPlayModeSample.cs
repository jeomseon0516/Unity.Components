using Jeomseon.Components;
using UnityEngine;

namespace Jeomseon.Samples.Components
{
    [RequireComponent(typeof(MovementTracker))]
    public sealed class MovementTrackerPlayModeSample : MonoBehaviour
    {
        private const float MoveDuration = 2f;
        private const float PauseDuration = 1f;
        private const float MoveSpeed = 2f;

        private MovementTracker _movementTracker;
        private int _codeMoveBeganCount;
        private int _codeMoveOngoingCount;
        private int _codeMoveEndedCount;
        private int _inspectorMoveBeganCount;
        private int _inspectorMoveOngoingCount;
        private int _inspectorMoveEndedCount;
        private Vector3 _lastDelta;

        private void Awake()
        {
            _movementTracker = GetComponent<MovementTracker>();
        }

        private void OnEnable()
        {
            _movementTracker.MoveBegan += OnMoveBegan;
            _movementTracker.MoveOngoing += OnMoveOngoing;
            _movementTracker.MoveEnded += OnMoveEnded;
        }

        private void OnDisable()
        {
            _movementTracker.MoveBegan -= OnMoveBegan;
            _movementTracker.MoveOngoing -= OnMoveOngoing;
            _movementTracker.MoveEnded -= OnMoveEnded;
        }

        private void FixedUpdate()
        {
            float cycleTime = MoveDuration + PauseDuration;
            if (Mathf.Repeat(Time.fixedTime, cycleTime) < MoveDuration)
            {
                transform.position += Vector3.right * (MoveSpeed * Time.fixedDeltaTime);
            }
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(16, 16, 400, 24), $"Code - began: {_codeMoveBeganCount}, ongoing: {_codeMoveOngoingCount}, ended: {_codeMoveEndedCount}");
            GUI.Label(new Rect(16, 40, 400, 24), $"Inspector - began: {_inspectorMoveBeganCount}, ongoing: {_inspectorMoveOngoingCount}, ended: {_inspectorMoveEndedCount}");
            GUI.Label(new Rect(16, 64, 400, 24), $"Last code delta: {_lastDelta}");
        }

        private void OnMoveBegan(Vector3 delta)
        {
            _codeMoveBeganCount++;
            _lastDelta = delta;
        }

        private void OnMoveOngoing(Vector3 delta)
        {
            _codeMoveOngoingCount++;
            _lastDelta = delta;
        }

        private void OnMoveEnded(Vector3 delta)
        {
            _codeMoveEndedCount++;
            _lastDelta = delta;
        }

        public void OnMoveBeganFromInspector(Vector3 _)
        {
            _inspectorMoveBeganCount++;
        }

        public void OnMoveOngoingFromInspector(Vector3 _)
        {
            _inspectorMoveOngoingCount++;
        }

        public void OnMoveEndedFromInspector(Vector3 _)
        {
            _inspectorMoveEndedCount++;
        }
    }
}
