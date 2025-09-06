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

        private readonly GameRoopManager stateManager = new();

        void Start()
        {
            if (!gameObjectManager)
                Debug.LogError("gameObjectManagerがアタッチされていません");
            if (!buttonManager)
                Debug.LogError("buttonManagerがアタッチされていません");
            if (!effectLineRenderer)
                Debug.LogError("effectLineRendeererがアタッチされていません");

            effectLineRenderer.StateManagerInject(stateManager);
            stateManager.SetStatement(GameRoopState.Edit);
        }
        private void Update()
        {
            if (stateManager.State == GameRoopState.Play)
            {
                gameObjectManager.ExecuteVoidUpdate();
            }
        }

        public void OnPlayOrResume()
        {
            if (stateManager.State == GameRoopState.Edit)
            {
                // 編集状態だったならPlay
                stateManager.SetStatement(GameRoopState.Play);
                gameObjectManager.ExecuteVoidStart();
            }
            else if (stateManager.State == GameRoopState.Pause)
            {
                // 一時停止状態だったならResume
                stateManager.SetStatement(GameRoopState.Play);
            }
        }
        public void OnPausePlaying()
        {
            stateManager.SetStatement(GameRoopState.Pause);
        }
        public void OnStopPlaying()
        {
            stateManager.SetStatement(GameRoopState.Edit);
            gameObjectManager.ExecuteVoidStart();
        }
    }
}