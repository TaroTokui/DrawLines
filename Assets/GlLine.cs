using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Refered the link
http://ft-lab.ne.jp/cgi-bin-unity/wiki.cgi?page=unity%5Fscript%5Fopengl
*/

public class GlLine : MonoBehaviour {

	static Material lineMaterial;
// Use this for initialization

static void CreateLineMaterial()
{
    if (!lineMaterial)
    {
        // Unity has a built-in shader that is useful for drawing
        // simple colored things.
        Shader shader = Shader.Find("Hidden/Internal-Colored");
        lineMaterial = new Material(shader);
        lineMaterial.hideFlags = HideFlags.HideAndDontSave;
        // Turn on alpha blending
        lineMaterial.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        lineMaterial.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        // Turn backface culling off
        lineMaterial.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        // Turn off depth writes
        lineMaterial.SetInt("_ZWrite", 0);
    }
}

public void OnRenderObject()
{
    CreateLineMaterial();
    // Apply the line material
    lineMaterial.SetPass(0);

    GL.PushMatrix();
    // Set transformation matrix for drawing to
    // match our transform
    GL.MultMatrix(transform.localToWorldMatrix);

    float lineWidth = 100.0f;
    // スクリーン上のラインの太さに変換.
    float thisWidth = 1.0f / Screen.width * lineWidth * 0.5f;

    GL.Begin(GL.QUADS);
    GL.Color(Color.red);
    DrawLine2D(new Vector3(0.0f, 0.0f, 0.0f), new Vector3(0.0f, 0.8f, 0.0f), thisWidth);
    DrawLine2D(new Vector3(0.0f, 0.8f, 0.0f), new Vector3(0.5f, 0.5f, 0.0f), thisWidth);
    DrawLine2D(new Vector3(0.5f, 0.5f, 0.0f), new Vector3(0.0f, 0.0f, 0.0f), thisWidth);
    GL.End();
    GL.PopMatrix();
}

// 太さのある線を描画.
void DrawLine2D(Vector3 v0, Vector3 v1, float lineWidth)
{
    Vector3 n = ((new Vector3(v1.y, v0.x, 0.0f)) - (new Vector3(v0.y, v1.x, 0.0f))).normalized * lineWidth;
    GL.Vertex3(v0.x - n.x, v0.y - n.y, 0.0f);
    GL.Vertex3(v0.x + n.x, v0.y + n.y, 0.0f);
    GL.Vertex3(v1.x + n.x, v1.y + n.y, 0.0f);
    GL.Vertex3(v1.x - n.x, v1.y - n.y, 0.0f);
}
}