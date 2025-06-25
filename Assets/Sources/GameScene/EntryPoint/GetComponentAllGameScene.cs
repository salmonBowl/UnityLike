using UnityEngine;
using Zenject;

public class GetComponentAllGameScene : MonoBehaviour
{
    private readonly GameRootGameScene game;

    [Inject]
    public GetComponentAllGameScene(GameRootGameScene game) => this.game = game;

    void Start() => game.Start();
    void Update() => game.Update();

    // ���ې��E�ւ̓˓�! ���Ă��񂶂ł������悭�Ȃ��ł���

}
