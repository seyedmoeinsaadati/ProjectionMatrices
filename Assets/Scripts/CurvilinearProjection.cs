using UnityEngine;

[ExecuteInEditMode]
public class CurvilinearProjection : MonoBehaviour
{
    public float radius = 1;

    void LateUpdate()
    {
        Camera cam = GetComponent<Camera>();
        Matrix4x4 m = CurvilinearMatrix(radius);
        cam.projectionMatrix = m;
    }

    static Matrix4x4 CurvilinearMatrix(float radius)
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
        m[3, 3] = 1;
        return m;
    }
}
