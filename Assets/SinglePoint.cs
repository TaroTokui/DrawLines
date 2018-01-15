using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]

public class SinglePoint : MonoBehaviour {

    private void Start()
    {
        var mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3 (0, 0),
        };
        //mesh.normals = new Vector3[] {
        //    new Vector3 (0, 1.0f, 0),
        //};

        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;

        filter.mesh.SetIndices(MakeIndices(), MeshTopology.Points, 0);
    }

    int[] MakeIndices()
    {
        int[] indices = new int[] {
            0
        };

        return indices;
    }
}
