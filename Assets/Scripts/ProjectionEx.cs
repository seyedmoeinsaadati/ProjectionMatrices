using UnityEngine;

public static class ProjectionEx
{
    public static Matrix4x4 Wobble(this Matrix4x4 self, float speed)
    {
        self.m01 += Mathf.Cos(Time.time * 1.2F) * 0.1F * speed;
        self.m10 += Mathf.Sin(Time.time * 1.5F) * 0.1F * speed;
        return self;
    }
}