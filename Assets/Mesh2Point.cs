// reffered from
// https://github.com/izmhr/DrawLineFromMesh

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesh2Point : MonoBehaviour {

    private MeshFilter meshFilter;
    private Vector3[] vertices;
    private int[] triangles;

    // Use this for initialization
    void Start () {

        meshFilter = GetComponent<MeshFilter>();

        if (meshFilter.mesh == null) return;

        // MeshTopologyの確認
        MeshTopology topo = meshFilter.mesh.GetTopology(0);
        Debug.Log(topo); // Triangles と出力される

        triangles = meshFilter.mesh.triangles;
        meshFilter.mesh.SetIndices(MakeIndices(), MeshTopology.Points, 0);

        // 再度MeshTopologyの確認
        topo = meshFilter.mesh.GetTopology(0);
        Debug.Log(topo); // Lines と出力される
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    int[] MakeIndices()
    {
        int[] indices = new int[triangles.Length];
        int i = 0;
        for (int t = 0; t < triangles.Length; t++)
        {
            indices[i++] = triangles[t];
        }
        return indices;
    }
}
