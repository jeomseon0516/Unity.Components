using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Jeomseon.Unity.Components.Editor
{
    [CustomEditor(typeof(TransformFollower)), CanEditMultipleObjects]
    internal sealed class TransformFollowerEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
            InspectorElement.FillDefaultInspector(root, serializedObject, this);
            if (targets.Length != 1 || target is not TransformFollower follower)
                return root;

            var settings = new Foldout { text = "Runtime Settings", value = false };
            var axes = new EnumFlagsField("Axes", FollowAxes.None);
            var offset = new Vector3Field("Offset");
            var smoothTime = new FloatField("Smooth Time");
            axes.RegisterValueChangedCallback(_ => Apply());
            offset.RegisterValueChangedCallback(_ => Apply());
            smoothTime.RegisterValueChangedCallback(_ => Apply());

            settings.RegisterValueChangedCallback(change =>
            {
                if (change.newValue)
                    Refresh();
            });

            settings.Add(axes);
            settings.Add(offset);
            settings.Add(smoothTime);
            root.Add(settings);
            root.RegisterCallback<AttachToPanelEvent>(_ =>
            {
                EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
                Refresh();
            });
            root.RegisterCallback<DetachFromPanelEvent>(_ =>
                EditorApplication.playModeStateChanged -= OnPlayModeStateChanged);
            Refresh();
            return root;

            void OnPlayModeStateChanged(PlayModeStateChange state)
            {
                if (state == PlayModeStateChange.EnteredPlayMode)
                    root.schedule.Execute(Refresh);
                else
                    settings.style.display = DisplayStyle.None;
            }

            void Apply()
            {
                if (follower == null || !Application.IsPlaying(follower))
                    return;

                var time = smoothTime.value;
                if (float.IsFinite(time) && time >= 0f)
                    follower.SetSettings(new FollowSettings((FollowAxes)axes.value, offset.value, time));
            }

            void Refresh()
            {
                var isPlaying = follower != null && Application.IsPlaying(follower);
                settings.style.display = isPlaying ? DisplayStyle.Flex : DisplayStyle.None;
                if (!isPlaying)
                    return;

                var current = follower.Settings;
                axes.SetValueWithoutNotify(current.Axes);
                offset.SetValueWithoutNotify(current.Offset);
                smoothTime.SetValueWithoutNotify(current.SmoothTime);
            }
        }
    }
}
