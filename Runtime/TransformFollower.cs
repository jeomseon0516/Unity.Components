using UnityEngine;

namespace Jeomseon.Unity.Components
{
    public sealed class TransformFollower : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private TransformFollowerSettingsAsset settingsAsset;

        private FollowSettings _settings;
        private Transform _target;
        private Vector3 _velocity;
        private bool _hasRuntimeConfiguration;

        private void Start()
        {
            if (_hasRuntimeConfiguration || target == null || settingsAsset == null)
                return;

            Initialize(settingsAsset.ToSettings(), target);
        }

        public void Initialize(FollowSettings settings, Transform target)
        {
            SetSettings(settings);
            SetTarget(target, snap: true);
        }

        public void SetTarget(Transform target, bool snap = true)
        {
            _hasRuntimeConfiguration = true;
            _target = target;
            _velocity = Vector3.zero;

            if (snap && _target != null)
                UpdatePosition(0f, snap: true);
        }

        public void SetSettings(FollowSettings settings)
        {
            _hasRuntimeConfiguration = true;
            var changed = _settings.Axes ^ settings.Axes;

            // 축이 바뀐 곳만 속도를 초기화합니다.
            // 보간 시간만 바꾸면 현재 움직임이 이어집니다.
            if ((changed & FollowAxes.X) != 0) _velocity.x = 0f;
            if ((changed & FollowAxes.Y) != 0) _velocity.y = 0f;
            if ((changed & FollowAxes.Z) != 0) _velocity.z = 0f;

            _settings = settings;

            if (_settings.SmoothTime <= 0f)
                _velocity = Vector3.zero;
        }

        private void LateUpdate()
        {
            if (_target == null || Time.deltaTime <= 0f)
                return;

            UpdatePosition(Time.deltaTime, snap: false);
        }

        private void UpdatePosition(float deltaTime, bool snap)
        {
            var current = transform.position;
            var desired = _target.position + _settings.Offset;

            current.x = FollowAxis(current.x, desired.x, FollowAxes.X,
                ref _velocity.x, deltaTime, snap);
            current.y = FollowAxis(current.y, desired.y, FollowAxes.Y,
                ref _velocity.y, deltaTime, snap);
            current.z = FollowAxis(current.z, desired.z, FollowAxes.Z,
                ref _velocity.z, deltaTime, snap);

            transform.position = current;
        }

        private float FollowAxis(
            float current, float desired, FollowAxes axis,
            ref float velocity, float deltaTime, bool snap)
        {
            if ((_settings.Axes & axis) == 0)
            {
                velocity = 0f;
                return current;
            }

            if (!snap && _settings.SmoothTime > 0f)
                return Mathf.SmoothDamp(
                    current, desired, ref velocity,
                    _settings.SmoothTime, Mathf.Infinity, deltaTime);

            velocity = 0f;
            return desired;
        }
    }
}
