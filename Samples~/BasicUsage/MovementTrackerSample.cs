using Jeomseon.Components;
using UnityEngine;

namespace Jeomseon.Samples.Components
{
    [RequireComponent(typeof(MovementTracker))]
    public sealed class MovementTrackerSample : MonoBehaviour
    {
        private void OnEnable()
        {
            GetComponent<MovementTracker>().AddListenerOnMoveBegined(OnMoveBegan);
        }

        private static void OnMoveBegan(Vector3 delta)
        {
            Debug.Log($"이동 시작: {delta}");
        }
    }
}
