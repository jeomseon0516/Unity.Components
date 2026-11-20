using Jeomseon.Unity.Components;
using UnityEngine;

namespace Jeomseon.Samples.Components
{
    public sealed class TransformFollowerSample : MonoBehaviour
    {
        [SerializeField] private TransformFollower follower;

        private void Start()
        {
            follower.Initialize(new FollowSettings(FollowAxes.X, Vector3.right, 0.25f), transform);
        }

        private void Update()
        {
            transform.position = new Vector3(Mathf.Sin(Time.time) * 3f, Mathf.Cos(Time.time), 0f);
        }
    }
}
