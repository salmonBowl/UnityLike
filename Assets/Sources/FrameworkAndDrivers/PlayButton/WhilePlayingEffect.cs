using UnityEngine;
using Zenject;

using UnityLike.Entities.GameRoop;
using UnityLike.Entities.Shape;
using Radishmouse;

namespace UnityLike.FrameworkAndDrivers.PlayButton
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

        private GameRoopManager stateManager;

        /// <summary>
        /// 周回計算のための媒介変数です
        /// </summary>
        private float rotateParameter = 0;

        public void StateManagerInject(GameRoopManager stateManager)
        {
            this.stateManager = stateManager;
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
            switch(stateManager.State)
            {
                case GameRoopState.Edit:
                    lineRenderer.enabled = false;
                    break;
                case GameRoopState.Play:
                    lineRenderer.enabled = true;
                    LightingUpdate();
                    break;
                case GameRoopState.Pause:
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