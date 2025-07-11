using UnityEngine;
using Zenject;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class GameRootMonoBehaviour : MonoBehaviour
    {
        [Inject]
        private readonly GameRootGameScene game;

        void Start() => game.Start();
        void Update() => game.Update();

        // 抽象世界への突入! ってかんじでかっこよくないですか

    }
}
