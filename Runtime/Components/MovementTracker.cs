using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Jeomseon.Components
{
    [DisallowMultipleComponent]
    public sealed class MovementTracker : MonoBehaviour
    {
        private const float ThresholdLimitMin = 0.01f;
        private const float ThresholdLimitMax = 0.5f;

        /// <summary>
        /// .. 움직임을 감지하는 오차범위
        /// </summary>
        public float PositionThreshold
        {
            get => positionThreshold;
            set => positionThreshold = Mathf.Clamp(value, ThresholdLimitMin, ThresholdLimitMax);
        }

        [FormerlySerializedAs("_positionThreshold")] [SerializeField, Range(ThresholdLimitMin, ThresholdLimitMax)]
        private float positionThreshold = 0.01f;

        private Vector3 _previousPosition;
        private bool _isMoving;

        public event Action<Vector3> MoveBegan;
        public event Action<Vector3> MoveOngoing;
        public event Action<Vector3> MoveEnded;

        private void OnEnable()
        {
            _previousPosition = transform.position;
            _isMoving = false;
        }

        private void FixedUpdate()
        {
            Vector3 currentPosition = transform.position;

            bool currentlyMoving = HasMoved(currentPosition, _previousPosition, positionThreshold);

            switch (currentlyMoving)
            {
                case true when !_isMoving:
#if DEBUG
                    Debug.Log("Move Begin");
#endif
                    MoveBegan?.Invoke(currentPosition - _previousPosition);
                    _isMoving = true;
                    break;
                case false when _isMoving:
#if DEBUG
                    Debug.Log("Move Ended");
#endif
                    MoveEnded?.Invoke(currentPosition - _previousPosition);
                    _isMoving = false;
                    break;
                case true when _isMoving:
#if DEBUG
                    Debug.Log("Moving");
#endif
                    MoveOngoing?.Invoke(currentPosition - _previousPosition);
                    break;
            }

            _previousPosition = currentPosition;
        }

        private static bool HasMoved(Vector3 currentPosition, Vector3 previousPosition, float threshold)
            => Vector3.Distance(currentPosition, previousPosition) > threshold;
    }
}
