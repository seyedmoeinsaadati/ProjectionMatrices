using UnityEngine;

[ExecuteInEditMode]
public class ReversePerspectiveProjectionTest : MonoBehaviour
{
    [Range(0, 1)] public float weight;
    public float offset;

    public float wobbleSpeed;

    void LateUpdate()
    {
        Camera cam = GetComponent<Camera>();
        Matrix4x4 m =
            StandardProjectionMatrix.ReversePerspectiveProjection(cam.orthographicSize, cam.aspect, weight, offset);
        m = m.Wobble(wobbleSpeed);
        cam.projectionMatrix = m;
    }
}