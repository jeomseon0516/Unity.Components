using Jeomseon.Unity.Components;
using UnityEngine;

namespace Jeomseon.Samples.Components
{
    public sealed class TransformFollowerSample : MonoBehaviour
    {
        [SerializeField] private TransformFollower follower;

        [Header("Follow Settings")]
        [Tooltip("Only these world-space axes follow the target. Try X, X and Y, or All in Play Mode.")]
        [SerializeField] private FollowAxes axes = FollowAxes.X;
        [SerializeField] private Vector3 offset = new(1.25f, 0f, 0f);
        [SerializeField, Min(0f)] private float smoothTime = 0.25f;

        private FollowSettings _appliedSettings;

        private void Start()
        {
            _appliedSettings = new FollowSettings(axes, offset, smoothTime);
            follower.Initialize(_appliedSettings, transform);
        }

        private void Update()
        {
            var settings = new FollowSettings(axes, offset, smoothTime);
            if (settings.Axes != _appliedSettings.Axes ||
                !settings.Offset.Equals(_appliedSettings.Offset) ||
                settings.SmoothTime != _appliedSettings.SmoothTime)
            {
                follower.SetSettings(settings);
                _appliedSettings = settings;
            }

            var time = Time.time;
            transform.position = new Vector3(
                Mathf.Sin(time) * 3f,
                Mathf.Cos(time) * 1.2f,
                Mathf.Sin(time * 1.5f) * 1.5f);
        }

        private void OnValidate()
        {
            smoothTime = float.IsFinite(smoothTime) ? Mathf.Max(0f, smoothTime) : 0f;
        }
    }
}
