using UnityEngine;

namespace Jeomseon.Unity.Components
{
    [CreateAssetMenu(menuName = "Jeomseon/Components/Follow Settings", fileName = "FollowSettings")]
    public sealed class TransformFollowerSettingsAsset : ScriptableObject
    {
        [SerializeField] private FollowAxes axes = FollowAxes.All;
        [SerializeField] private Vector3 offset;
        [SerializeField, Min(0f)] private float smoothTime = 0.25f;

        public FollowSettings ToSettings()
        {
            var validSmoothTime = float.IsFinite(smoothTime) ? Mathf.Max(0f, smoothTime) : 0f;
            return new FollowSettings(axes, offset, validSmoothTime);
        }
    }
}
