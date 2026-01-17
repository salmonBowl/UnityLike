using UnityEngine;

namespace UnityLike.Application
{
    public class GameSceneMain : Main
    {
        [SerializeField]
        private GameSceneApplicationFactory applicationFactory;

        protected override void Awake()
        {
            currentScene.Is(new GameScene(applicationFactory));
        }
    }
}
