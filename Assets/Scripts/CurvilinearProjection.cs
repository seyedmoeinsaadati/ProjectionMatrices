using UnityEngine;

[ExecuteInEditMode]
public class CurvilinearProjection : MonoBehaviour
{
    public float radius = 1;
    public float aspect = 1;

    public float weight, origin;

    private void LateUpdate()
    {
        Camera cam = GetComponent<Camera>();
        // Matrix4x4 m = CurvilinearMatrix(radius, origin);
        // Matrix4x4 m = CurvilinearOrthographicMatrix(aspect, cam.nearClipPlane, cam.farClipPlane, radius);
        Matrix4x4 m = CurvilinearPerspectiveMatrix(radius, cam.aspect, cam.orthographicSize, weight, origin);
        cam.projectionMatrix = m;
    }

    private static Matrix4x4 CurvilinearMatrix(float radius, float origin)
    {
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = radius * 2;
        m[0, 1] = 0;
        m[0, 2] = 0;
        m[0, 3] = 0;
        m[1, 0] = 0;
        m[1, 1] = radius * 2;
        m[1, 2] = 0;
        m[1, 3] = 0;
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = 1;
        m[2, 3] = radius;
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = 0;
        m[3, 3] = radius * 2;
        return m;
    }

    private static Matrix4x4 CurvilinearOrthographicMatrix(float aspect, float near, float far,
        float radius)
    {
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = radius * 2 * near / aspect;
        m[0, 1] = 0;
        m[0, 2] = 0;
        m[0, 3] = 0;
        m[1, 0] = 0;
        m[1, 1] = -radius * 2 * near / aspect;
        m[1, 2] = 0;
        m[1, 3] = 0;
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = (radius - far / (far - near));
        m[2, 3] = far * near / (far - near);
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = -radius * 2;
        m[3, 3] = 0;
        return m;
    }

    // private static Matrix4x4 CurvilinearPerspectiveMatrix(float radius, float aspectRatio, float size, float weight,
    //     float offset)
    // {
    //     Matrix4x4 m = new Matrix4x4();
    //     m[0, 0] = 2 * radius / (aspectRatio * size);
    //     m[0, 1] = 0;
    //     m[0, 2] = 0;
    //     m[0, 3] = 0;
    //     m[1, 0] = 0;
    //     m[1, 1] = 2 * radius / size;
    //     m[1, 2] = 0;
    //     m[1, 3] = 0;
    //     m[2, 0] = 0;
    //     m[2, 1] = 0;
    //     m[2, 2] = .00001f;
    //     m[2, 3] = radius * weight;
    //     m[3, 0] = 0;
    //     m[3, 1] = 0;
    //     m[3, 2] = weight;
    //     m[3, 3] = 2 * radius;
    //     return m;
    // }
}