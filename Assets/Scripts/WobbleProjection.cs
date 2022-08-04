using UnityEngine;

public class WobbleProjection : MonoBehaviour
{
    private Matrix4x4 originalProjection;
    Camera cam;
    public float speed = 1;

    void Start()
    {
        cam = GetComponent<Camera>();
        originalProjection = cam.projectionMatrix;
    }

    void Update()
    {
        Matrix4x4 p = originalProjection;
        p.m01 += Mathf.Cos(Time.time * 1.2F) * 0.1F * speed;
        p.m10 += Mathf.Sin(Time.time * 1.5F) * 0.1F * speed;
        cam.projectionMatrix = p;
    }
}