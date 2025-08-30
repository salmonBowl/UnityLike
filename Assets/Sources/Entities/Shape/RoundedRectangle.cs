using System;
using UnityEngine;

namespace UnityLike.Entities.Shape
{
    [Serializable]
    public class RoundedRectangle
    {
        public Vector2 Position;
        public float Width;
        public float Height;
        public float RoundRadius;

        /// <summary>
        /// パラメーターとメンバー変数から矩形上の座標を計算します
        /// </summary>
        /// <param name="parameter">周期の長さは1.0です</param>
        /// <returns>メンバー変数のPositionを基準としたVector2の座標を返します</returns>
        public Vector2 CalculatePosition(float parameter)
        {
            // 制御点を指定します
            Vector2[][] controlPoints = new Vector2[][]
            {
                // 右上
                new Vector2[]
                {
                    new(Width - RoundRadius, Height),
                    new(Width, Height),
                    new(Width, Height - RoundRadius),
                },
                // 右
                new Vector2[] { new(Width, Height - RoundRadius), new(Width, -Height + RoundRadius) },
                // 右下
                new Vector2[]
                {
                    new(Width, -Height + RoundRadius),
                    new(Width, -Height),
                    new(Width - RoundRadius, -Height),
                },
                // 下
                new Vector2[] { new(Width - RoundRadius, -Height), new(-Width + RoundRadius, -Height) },
                // 左下
                new Vector2[]
                {
                    new(-Width + RoundRadius, -Height),
                    new(-Width, -Height),
                    new(-Width, -Height + RoundRadius),
                },
                // 左
                new Vector2[] { new(-Width, -Height + RoundRadius), new(-Width, Height - RoundRadius) },
                // 左上
                new Vector2[]
                {
                    new(-Width, Height - RoundRadius),
                    new(-Width, Height),
                    new(-Width + RoundRadius, Height),
                },
                // 上
                new Vector2[] { new(-Width + RoundRadius, Height), new(Width - RoundRadius, Height) }
            };

            // ジャグ配列から制御点のセットを取得
            Segment(parameter, out int index, out float iParameter);

            // ベジェ曲線の計算
            Vector2 bezierPoint = GetBezierPoint(controlPoints[index], iParameter);
            return bezierPoint + Position;
        }
        /// <summary>
        /// ベジェ曲線の制御点配列から全体のパラメーターを区間のパラメーターに変更します
        /// </summary>
        /// <param name="parameter">全体のパラメーター</param>
        /// <param name="index">区間の場所</param>
        /// <param name="intervalNormalizedParameter">区間のパラメーター</param>
        private void Segment(float parameter, out int index, out float intervalNormalizedParameter)
        {
            // パラメータを主値に正規化
            float normalizedParameter = parameter % 1.0f;
            if (normalizedParameter < 0)
            {
                normalizedParameter += 1.0f;
            }

            // 全体を8つの区間に均等に分割
            float segmentParameter = normalizedParameter * 8;
            index = Mathf.FloorToInt(segmentParameter);
            intervalNormalizedParameter = segmentParameter - index;

            // 端点の処理
            if (index >= 8)
            {
                index = 0;
            }
        }
        /// <summary>
        /// 一般のベジェ曲線を再帰的に計算します
        /// </summary>
        /// <param name="points">制御点の配列</param>
        /// <param name="t">0～1のパラメーター</param>
        /// <returns>パラメーターtに対応した座標を計算します</returns>
        private Vector2 GetBezierPoint(Vector2[] points, float t)
        {
            if (points.Length == 1)
            {
                return points[0];
            }

            Vector2[] nextPoints = new Vector2[points.Length - 1];
            for (int i = 0; i < nextPoints.Length; i++)
            {
                nextPoints[i] = Vector2.Lerp(points[i], points[i + 1], t);
            }

            return GetBezierPoint(nextPoints, t);
        }
    }
}