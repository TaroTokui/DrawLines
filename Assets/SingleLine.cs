using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
[RequireComponent (typeof(MeshFilter))]

public class SingleLine : MonoBehaviour {

    private void Start()
    {
        var mesh = new Mesh();
        mesh.vertices = new Vector3[] {
            new Vector3 (0, 1f),
            new Vector3 (0, -1f),
        };

        var filter = GetComponent<MeshFilter>();
        filter.sharedMesh = mesh;

        filter.mesh.SetIndices(MakeIndices(), MeshTopology.Lines, 0);
    }

    int[] MakeIndices()
    {
        int[] indices = new int[] {
            0, 1
        };
        
        return indices;
    }
}
