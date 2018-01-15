# DrawLines
Unityで線や点を描く方法を試す

Mesh.SetIndicesを使って頂点とトポロジーを設定する。
https://docs.unity3d.com/ja/530/ScriptReference/Mesh.SetIndices.html

線の場合
meshFilter.mesh.SetIndices(MakeIndices(), MeshTopology.Lines, 0);

点の場合
meshFilter.mesh.SetIndices(MakeIndices(), MeshTopology.Points, 0);

# ScripでMeshを作る
1. EmptyObjectを作成する。
1. Mesh Rendererコンポーネントを追加
1. Mesh Filterコンポーネントを追加
1. スクリプトを作成
1. Mesh FilterにMeshを追加する
