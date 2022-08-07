using UnityEngine;


public class VertexGizmos : MonoBehaviour
{
    public MeshFilter meshFilter;
    private Mesh mesh;
    public float gizmosSize = 0.1f;

    private void OnDrawGizmos()
    {
        if (mesh != null)
        {
            Gizmos.color = Color.black;
            for (int i = 0; i < mesh.vertexCount; i++)
            {
                Gizmos.DrawSphere(transform.TransformPoint(mesh.vertices[i]), gizmosSize);
            }
        }
    }

    private void Reset()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
    }
}