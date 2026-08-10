using Jeomseon.Components;
using UnityEngine;

namespace Jeomseon.Samples.Components
{
    [RequireComponent(typeof(MovementTracker))]
    public sealed class MovementTrackerSample : MonoBehaviour
    {
        private MovementTracker _movementTracker;

        private void Awake()
        {
            _movementTracker = GetComponent<MovementTracker>();
        }

        private void OnEnable()
        {
            _movementTracker.MoveBegan += OnMoveBegan;
        }

        private void OnDisable()
        {
            _movementTracker.MoveBegan -= OnMoveBegan;
        }

        private static void OnMoveBegan(Vector3 delta)
        {
            Debug.Log($"이동 시작: {delta}");
        }
    }
}
