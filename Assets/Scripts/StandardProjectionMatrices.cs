using UnityEditor;
using UnityEngine;

public class StandardProjectionMatrix : MonoBehaviour
{
    public static Matrix4x4 OrthographicProjection(float left, float right, float bottom, float top, float near,
        float far)
    {
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = 2.0f / (right - left);
        m[0, 1] = 0;
        m[0, 2] = 0;
        m[0, 3] = -(right + left) / (right - left);
        m[1, 0] = 0;
        m[1, 1] = 2.0f / (top - bottom);
        m[1, 2] = 0;
        m[1, 3] = -(top + bottom) / (top - bottom);
        m[2, 0] = 0;
        m[2, 1] = 0;
        m[2, 2] = 1 / (far - near);
        m[2, 3] = -near / (far - near);
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = 0;
        m[3, 3] = 1;
        return m;
    }

    #region Perspective

    public static Matrix4x4 Perspective(float near, float far)
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
        m[2, 2] = far + near;
        m[2, 3] = -near * far;
        m[3, 0] = 0;
        m[3, 1] = 0;
        m[3, 2] = -1;
        m[3, 3] = 0;
        return m;
    }

    public static Matrix4x4 PerspectiveProjection(float left, float right, float bottom, float top, float near,
        float far)
    {
        float x = 2.0F * near / (right - left);
        float y = 2.0F * near / (top - bottom);
        float a = (right + left) / (right - left);
        float b = (top + bottom) / (top - bottom);
        float c = -(far + near) / (far - near);
        float d = -(2.0F * far * near) / (far - near);
        float e = -1.0F;

        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = x;
        m[0, 2] = a;
        m[1, 1] = y;
        m[1, 2] = b;
        m[2, 2] = c;
        m[2, 3] = d;
        m[3, 2] = e;
        return m;
    }

    public static Matrix4x4 PerspectiveProjection(float left, float right, float bottom, float top, float near,
        float far, float fieldOfView, float aspectRatio)
    {
        float tan = Mathf.Tan(fieldOfView / 2);

        float x = 1 / aspectRatio * tan;
        float y = 1 / tan;
        float a = (right + left) / (right - left);
        float b = (top + bottom) / (top - bottom);
        float c = -(far + near) / (far - near);
        float d = -(2.0F * far * near) / (far - near);
        float e = -1.0F;

        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = x;
        m[0, 2] = a;
        m[1, 1] = y;
        m[1, 2] = b;
        m[2, 2] = c;
        m[2, 3] = d;
        m[3, 2] = e;
        return m;
    }

    #endregion

    #region ReversePerspective

    /// <param name="weight">percent of reverse perspective [0, 1]</param>
    /// <param name="offset">distance from camera position</param>
    public static Matrix4x4 ReversePerspectiveProjection(float verticalSize, float aspectRatio, float weight,
        float offset = 0)
    {
        Matrix4x4 m = new Matrix4x4();
        m.m00 = 1 / verticalSize * aspectRatio;
        m.m11 = 1 / verticalSize;
        m.m22 = 0.000001f;
        m.m23 = weight;
        m.m32 = weight;
        m.m33 = 1.0f + offset * weight;
        return m;
    }

    #endregion
}