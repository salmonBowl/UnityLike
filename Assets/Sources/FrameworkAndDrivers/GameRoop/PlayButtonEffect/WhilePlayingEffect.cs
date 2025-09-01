using UnityEngine;
using Zenject;

using UnityLike.Entities.GameRoop;
using UnityLike.Entities.Shape;
using Radishmouse;

namespace UnityLike.FrameworkAndDrivers.GameRoop
{
    /// <summary>
    /// ゲームの実行中にPlayButtonを回るエフェクトを表現します。UILineRendererにアタッチしてください。
    /// </summary>
    [RequireComponent(typeof(UILineRenderer))]
    public class WhilePlayingEffect : MonoBehaviour
    {
        private UILineRenderer lineRenderer;

        [SerializeField]
        private float lineRotateSpeed;
        [SerializeField]
        private int lineLength;

        [SerializeField, Header("lineRendererの周回軌道を指定します")]
        private RoundedRectangle orbit;

        private GameRoopManager statementManager;

        /// <summary>
        /// 周回計算のための媒介変数です
        /// </summary>
        private float rotateParameter = 0;

        public void StatementManagerInject(GameRoopManager statementManager)
        {
            this.statementManager = statementManager;
        }

        void Start()
        {
            lineRenderer = GetComponent<UILineRenderer>();
            if (!lineRenderer)
                Debug.LogError("このファイルはUILineRendererにアタッチしてください");
        }
        void Update()
        {
            LineActiveManagement();
        }

        private void LineActiveManagement()
        {
            switch(statementManager.Statement)
            {
                case GameRoopStatement.Edit:
                    lineRenderer.enabled = false;
                    break;
                case GameRoopStatement.Play:
                    lineRenderer.enabled = true;
                    LightingUpdate();
                    break;
                case GameRoopStatement.Pause:
                    lineRenderer.enabled = true;
                    break;
                default:
                    throw new System.ArgumentException("GameRoopStatementが予期しない値を取っています");
            }
        }

        private void LightingUpdate()
        {
            rotateParameter += lineRotateSpeed * Time.deltaTime;

            int totalVertices = 20; // 一周の分割数
            Vector2[] positions = new Vector2[lineLength];

            float segmentLength = 1f / totalVertices;

            for (int i = 0; i < lineLength; i++)
            {
                float parameter = rotateParameter + (i * segmentLength);
                positions[i] = orbit.CalculatePosition(parameter);
            }
            lineRenderer.SetPositions(positions);
            lineRenderer.Render();
        }
    }
}