using UnityEngine;


public class VertexGizmos : MonoBehaviour
{
    public MeshFilter meshFilter;
    private Mesh mesh;

    private void OnDrawGizmos()
    {
        if (mesh != null)
        {
            Gizmos.color = Color.black;
            for (int i = 0; i < mesh.vertexCount; i++)
            {
                Gizmos.DrawSphere(transform.TransformPoint(mesh.vertices[i]), .05f);
            }
        }
    }

    private void Reset()
    {
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
    }
}