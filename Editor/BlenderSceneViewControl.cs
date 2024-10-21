using UnityEditor;
using UnityEditor.ShortcutManagement;
using UnityEngine;

namespace UnityAyoExtensions.Editor
{
    public static class BlenderSceneViewControl
    {
        private static readonly Quaternion DefaultDirection = Quaternion.Euler(30, -135, 0);

        [Shortcut("BlenderSceneViewControl/Front View", KeyCode.Keypad1, displayName = "Blender Scene View Control/Front View")]
        private static void SetFrontView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(0, 180, 0));
        }

        [Shortcut("BlenderSceneViewControl/Right View", KeyCode.Keypad3, displayName = "Blender Scene View Control/Right View")]
        private static void SetRightView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(0, -90, 0));
        }

        [Shortcut("BlenderSceneViewControl/Top View", KeyCode.Keypad7, displayName = "Blender Scene View Control/Top View")]
        private static void SetTopView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(90, 0, 0));
        }

        [Shortcut("BlenderSceneViewControl/Bottom View", KeyCode.Keypad9, displayName = "Blender Scene View Control/Bottom View")]
        private static void SetBottomView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(-90, 0, 0));
        }

        [Shortcut("BlenderSceneViewControl/Rotate Down", KeyCode.Keypad2, displayName = "Blender Scene View Control/Rotate Down")]
        private static void RotateDown()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.right, -15);
        }

        [Shortcut("BlenderSceneViewControl/Rotate Up", KeyCode.Keypad8, displayName = "Blender Scene View Control/Rotate Up")]
        private static void RotateUp()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.right, 15);
        }

        [Shortcut("BlenderSceneViewControl/Rotate Left", KeyCode.Keypad4, displayName = "Blender Scene View Control/Rotate Left")]
        private static void RotateLeft()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.up, -15);
        }

        [Shortcut("BlenderSceneViewControl/Rotate Right", KeyCode.Keypad6, displayName = "Blender Scene View Control/Rotate Right")]
        private static void RotateRight()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.up, 15);
        }

        [Shortcut("BlenderSceneViewControl/Toggle Orthographic", KeyCode.Keypad5, displayName = "Blender Scene View Control/Toggle Orthographic")]
        private static void ToggleOrthographic()
        {
            SceneView sceneView = SceneView.lastActiveSceneView;
            if (sceneView == null) return;

            sceneView.orthographic = !sceneView.orthographic;
            sceneView.Repaint();
        }

        [Shortcut("BlenderSceneViewControl/Reset View", KeyCode.Keypad0, displayName = "Blender Scene View Control/Reset View")]
        private static void ResetSceneViewRotation()
        {
            SceneView sceneView = SceneView.lastActiveSceneView;
            if (sceneView == null) return;

            sceneView.LookAt(sceneView.pivot, DefaultDirection);
            sceneView.orthographic = false; // Set to perspective view
            sceneView.Repaint();
        }

        private static void RotateSceneViewTo(SceneView sceneView, Quaternion rotation)
        {
            if (sceneView == null) return;

            sceneView.LookAt(sceneView.pivot, rotation);
            sceneView.orthographic = true;
            sceneView.Repaint();
        }

        private static void RotateSceneView(SceneView sceneView, Vector3 axis, float angle)
        {
            if (sceneView == null) return;

            sceneView.rotation *= Quaternion.AngleAxis(angle, axis);
            sceneView.Repaint();
        }
    }
}