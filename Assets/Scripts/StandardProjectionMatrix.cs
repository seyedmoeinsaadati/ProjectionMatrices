using UnityEngine;

public class StandardProjectionMatrix : MonoBehaviour
{
    public static Matrix4x4 OrthographicMatrix(float left, float right, float bottom, float top, float near, float far, float factor = 1)
    {
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = 2.0f / (right - left);
        m[0, 1] = 0;
        m[0, 2] = 0;
        m[0, 3] = -(right + left) / (right - left);
        m[1, 0] = 0;
        m[1, 1] = 2.0f / (top - bottom);
        m[1, 2] = 0;
        m[1, 3] = (top + bottom) / (top - bottom);
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = -1 / (far - near);
        m[2, 3] = -near / (far - near);
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = 0;
        m[3, 3] = 1;
        return m;
    }
    public static Matrix4x4 PerspectiveMatrix(float near, float far)
    {
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = near;
        m[0, 1] = 0;
        m[0, 2] = 0;
        m[0, 3] = 0;
        m[1, 0] = 0;
        m[1, 1] = near;
        m[1, 2] = 0;
        m[1, 3] = 0;
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = near + far;
        m[2, 3] = -near * far;
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = -1;
        m[3, 3] = 0;
        return m;
    }

    public static Matrix4x4 PerspectiveMatrix(float left, float right, float bottom, float top, float near, float far)
    {
        return OrthographicMatrix(left, right, bottom, top, near, far) * PerspectiveMatrix(near, far);
    }
}
