using UnityEngine;
using Zenject;

public class GetComponentAllGameScene : MonoBehaviour
{
    private readonly GameRootGameScene game;

    [Inject]
    public GetComponentAllGameScene(GameRootGameScene game) => this.game = game;

    void Start() => game.Start();
    void Update() => game.Update();

    // ’ŠÛ¢ŠE‚Ö‚Ì“Ë“ü! ‚Á‚Ä‚©‚ñ‚¶‚Å‚©‚Á‚±‚æ‚­‚È‚¢‚Å‚·‚©

}
