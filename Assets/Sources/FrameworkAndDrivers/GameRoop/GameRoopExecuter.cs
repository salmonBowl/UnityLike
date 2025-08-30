using UnityEngine;
using Zenject;

using UnityLike.Entities.GameRoop;
using UnityLike.FrameworkAndDrivers.GameObjectManagement;

namespace UnityLike.FrameworkAndDrivers.GameRoop
{
    public class GameRoopExecuter : MonoBehaviour
    {
        [SerializeField]
        private GameObjectManager gameObjectManager;
        [SerializeField]
        private PlayButtonsEventManager buttonManager;
        [SerializeField]
        private WhilePlayingEffect effectLineRenderer;

        private readonly GameRoopManager statementManager = new();

        void Start()
        {
            if (!gameObjectManager)
                Debug.LogError("gameObjectManagerがアタッチされていません");
            if (!buttonManager)
                Debug.LogError("buttonManagerがアタッチされていません");
            if (!effectLineRenderer)
                Debug.LogError("effectLineRendeererがアタッチされていません");

            effectLineRenderer.StatementManagerInject(statementManager);
            statementManager.SetStatement(GameRoopStatement.Edit);
        }
        private void Update()
        {
            if (statementManager.Statement == GameRoopStatement.Play)
            {
                gameObjectManager.ExecuteVoidUpdate();
            }
        }

        public void OnPlayOrResume()
        {
            if (statementManager.Statement == GameRoopStatement.Edit)
            {
                // 編集状態だったならPlay
                statementManager.SetStatement(GameRoopStatement.Play);
                gameObjectManager.ExecuteVoidStart();
            }
            else if (statementManager.Statement == GameRoopStatement.Pause)
            {
                // 一時停止状態だったならResume
                statementManager.SetStatement(GameRoopStatement.Play);
            }
        }
        public void OnPausePlaying()
        {
            statementManager.SetStatement(GameRoopStatement.Pause);
        }
        public void OnStopPlaying()
        {
            statementManager.SetStatement(GameRoopStatement.Edit);
            gameObjectManager.ExecuteVoidStart();
        }
    }
}