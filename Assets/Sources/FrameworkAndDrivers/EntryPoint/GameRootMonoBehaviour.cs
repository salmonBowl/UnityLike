using UnityEngine;
using Zenject;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class GameRootMonoBehaviour : MonoBehaviour
    {
        private readonly GameRootGameScene game = new();

        void Start() => game.Start();
        void Update() => game.Update();

        // ’ŠÛ¢ŠE‚Ö‚Ì“Ë“ü! ‚Á‚Ä‚©‚ñ‚¶‚Å‚©‚Á‚±‚æ‚­‚È‚¢‚Å‚·‚©

    }
}
