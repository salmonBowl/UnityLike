using UnityEngine;
using UnityEngine.UI;

namespace Radishmouse
{
    [RequireComponent(typeof(CanvasRenderer))]
    public class UILineRenderer : MaskableGraphic
    {
        public Vector2[] points;

        public float thickness = 10f;
        public bool center = true;

        public void SetPositions(Vector2[] points)
        {
            this.points = points;
        }
        public void Render()
        {
            SetVerticesDirty();
        }
        protected override void OnPopulateMesh(VertexHelper vh)
        {
            vh.Clear();

            if (points == null || points.Length < 2)
                return;

            // 最初の頂点インデックス
            int vertexIndex = 0;

            for (int i = 0; i < points.Length - 1; i++)
            {
                CreateLineSegment(points[i], points[i + 1], vh);

                // 矩形の4つの頂点に対応するインデックス
                vh.AddTriangle(vertexIndex, vertexIndex + 1, vertexIndex + 3);
                vh.AddTriangle(vertexIndex + 3, vertexIndex + 2, vertexIndex);

                // 次のセグメントの開始インデックスを更新
                vertexIndex += 4;
            }
        }

        private void CreateLineSegment(Vector2 point1, Vector2 point2, VertexHelper vh)
        {
            // 線分の方向と法線ベクトルを計算
            Vector2 direction = (point2 - point1).normalized;
            Vector2 offset = new Vector2(-direction.y, direction.x) * thickness / 2f;

            // Create vertex template
            UIVertex vertex = UIVertex.simpleVert;
            vertex.color = color;

            // Create the start of the segment
            vertex.position = point1 - offset;
            vh.AddVert(vertex);
            vertex.position = point1 + offset;
            vh.AddVert(vertex);

            // Create the end of the segment
            vertex.position = point2 - offset;
            vh.AddVert(vertex);
            vertex.position = point2 + offset;
            vh.AddVert(vertex);

            // Also add the end point
            vertex.position = point2 - offset;
            //vh.AddVert(vertex);
        }
        private void CreateLineSegment(Vector3 point1, Vector3 point2, VertexHelper vh)
        {
            Vector3 offset = center ? (rectTransform.sizeDelta / 2) : Vector2.zero;

            // Create vertex template
            UIVertex vertex = UIVertex.simpleVert;
            vertex.color = color;

            // Create the start of the segment
            Quaternion point1Rotation = Quaternion.Euler(0, 0, RotatePointTowards(point1, point2) + 90);
            vertex.position = point1Rotation * new Vector3(-thickness / 2, 0);
            vertex.position += point1 - offset;
            vh.AddVert(vertex);
            vertex.position = point1Rotation * new Vector3(thickness / 2, 0);
            vertex.position += point1 - offset;
            vh.AddVert(vertex);

            // Create the end of the segment
            Quaternion point2Rotation = Quaternion.Euler(0, 0, RotatePointTowards(point2, point1) - 90);
            vertex.position = point2Rotation * new Vector3(-thickness / 2, 0);
            vertex.position += point2 - offset;
            vh.AddVert(vertex);
            vertex.position = point2Rotation * new Vector3(thickness / 2, 0);
            vertex.position += point2 - offset;
            vh.AddVert(vertex);

            // Also add the end point
            vertex.position = point2 - offset;
            vh.AddVert(vertex);
        }

        /// <summary>
        /// Gets the angle that a vertex needs to rotate to face target vertex
        /// </summary>
        /// <param name="vertex">The vertex being rotated</param>
        /// <param name="target">The vertex to rotate towards</param>
        /// <returns>The angle required to rotate vertex towards target</returns>
        private float RotatePointTowards(Vector2 vertex, Vector2 target)
        {
            return (float)(Mathf.Atan2(target.y - vertex.y, target.x - vertex.x) * (180 / Mathf.PI));
        }
    }
}