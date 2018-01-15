# DrawLines
Unityで線や点を描く方法を試す

Mesh.SetIndicesを使って頂点とトポロジーを設定する。
https://docs.unity3d.com/ja/530/ScriptReference/Mesh.SetIndices.html

線の場合
meshFilter.mesh.SetIndices(MakeIndices(), MeshTopology.Lines, 0);

点の場合
meshFilter.mesh.SetIndices(MakeIndices(), MeshTopology.Points, 0);

