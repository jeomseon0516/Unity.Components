using UnityEngine;

namespace Jeomseon.Samples.Components
{
    public sealed class TransformFollowerSample : MonoBehaviour
    {
        private void Update()
        {
            var time = Time.time;
            transform.position = new Vector3(
                Mathf.Sin(time) * 3f,
                Mathf.Cos(time) * 1.2f,
                Mathf.Sin(time * 1.5f) * 1.5f);
        }
    }
}
