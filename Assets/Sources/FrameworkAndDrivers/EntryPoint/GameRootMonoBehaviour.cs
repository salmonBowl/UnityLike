using UnityEngine;
using Zenject;

public class GameRootMonoBehaviour : MonoBehaviour
{
    [Inject]
    private readonly GameRootGameScene game;

    void Start() => game.Start();
    void Update() => game.Update();

    // ’ŠÛ¢ŠE‚Ö‚Ì“Ë“ü! ‚Á‚Ä‚©‚ñ‚¶‚Å‚©‚Á‚±‚æ‚­‚È‚¢‚Å‚·‚©

}
