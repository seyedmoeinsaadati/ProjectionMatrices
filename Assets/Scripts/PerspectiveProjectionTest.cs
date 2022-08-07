using UnityEngine;

[ExecuteInEditMode]
public class PerspectiveProjection : MonoBehaviour
{
    public float left = -0.2F;
    public float right = 0.2F;
    public float top = 0.2F;
    public float bottom = -0.2F;

    void LateUpdate()
    {
        Camera cam = GetComponent<Camera>();
        Matrix4x4 m = StandardProjectionMatrix.PerspectiveProjection(left, right, bottom, top, cam.nearClipPlane,
            cam.farClipPlane);
        cam.projectionMatrix = m;
    }
}