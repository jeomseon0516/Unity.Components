using System;
using UnityEngine;

namespace Jeomseon.Unity.Components
{
    public readonly struct FollowSettings
    {
        public FollowAxes Axes { get; }
        public Vector3 Offset { get; }
        public float SmoothTime { get; }

        public FollowSettings(FollowAxes axes, in Vector3 offset, float smoothTime)
        {
            if (float.IsNaN(smoothTime) ||
                float.IsInfinity(smoothTime) ||
                smoothTime < 0f)
            {
                throw new ArgumentOutOfRangeException(nameof(smoothTime));
            }

            Axes = axes & (FollowAxes.X | FollowAxes.Y | FollowAxes.Z);
            Offset = offset;
            SmoothTime = smoothTime;
        }
    }
}
