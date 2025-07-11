using UnityEngine;
using Zenject;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class GameRootMonoBehaviour : MonoBehaviour
    {
        private readonly GameRootGameScene game = new();

        void Start() => game.Start();
        void Update() => game.Update();

        // ���ې��E�ւ̓˓�! ���Ă��񂶂ł������悭�Ȃ��ł���

    }
}
