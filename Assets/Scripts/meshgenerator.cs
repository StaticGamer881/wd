using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class meshgenerator : MonoBehaviour
{
    Mesh mesh;
    public int xsize = 60;
    public int zsize = 60;
    Vector3[] vertices;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
    }
    private void Update()
    {

    }

    public void CreateShape()
    {
        vertices = new Vector3[(xsize + 1) * (zsize + 1)];
        for (int i = 0, z = 0; z <= zsize; z++)
        {
            for (int x = 0; x <= xsize; x++)
            {
                float y = Mathf.PerlinNoise(x * .2f, z * .2f) * 2f;
                vertices[i] = new Vector3(x, y, z);
                i++;
            }
        }
        int vert = 0;
        int tris = 0;
        triangles = new int[xsize * zsize * 6];
        for (int z = 0; z < zsize; z++)
        {
            for (int x = 0; x < xsize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xsize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xsize + 1;
                triangles[tris + 5] = vert + xsize + 2;
                vert++;
                tris += 6;

            }
            vert++;
        }


    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
        meshCollider.sharedMesh = mesh;
    }
}
