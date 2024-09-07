using UnityEditor;
using UnityEngine;

namespace UnityEditorTools.BlenderShortcuts
{
    public static class BlenderSceneViewControl
    {
        private static readonly Quaternion DefaultDirection = Quaternion.Euler(30, 45, 0);

        [MenuItem("Blender Scene View Control/Front View (Numpad 1)")]
        private static void SetFrontView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(0, 0, 0));
        }

        [MenuItem("Blender Scene View Control/Right View (Numpad 3)")]
        private static void SetRightView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(0, 90, 0));
        }

        [MenuItem("Blender Scene View Control/Top View (Numpad 7)")]
        private static void SetTopView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(90, 0, 0));
        }

        [MenuItem("Blender Scene View Control/Bottom View (Numpad 9)")]
        private static void SetBottomView()
        {
            RotateSceneViewTo(SceneView.lastActiveSceneView, Quaternion.Euler(-90, 0, 0));
        }

        [MenuItem("Blender Scene View Control/Rotate Down (Numpad 2)")]
        private static void RotateDown()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.right, -15);
        }

        [MenuItem("Blender Scene View Control/Rotate Up (Numpad 8)")]
        private static void RotateUp()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.right, 15);
        }

        [MenuItem("Blender Scene View Control/Rotate Left (Numpad 4)")]
        private static void RotateLeft()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.up, -15);
        }

        [MenuItem("Blender Scene View Control/Rotate Right (Numpad 6)")]
        private static void RotateRight()
        {
            RotateSceneView(SceneView.lastActiveSceneView, Vector3.up, 15);
        }

        [MenuItem("Blender Scene View Control/Toggle Orthographic (Numpad 5)")]
        private static void ToggleOrthographic()
        {
            SceneView sceneView = SceneView.lastActiveSceneView;
            if (sceneView == null) return;
            sceneView.orthographic = !sceneView.orthographic;
            sceneView.Repaint();
        }

        [MenuItem("Blender Scene View Control/Reset View (Numpad 0)")]
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
