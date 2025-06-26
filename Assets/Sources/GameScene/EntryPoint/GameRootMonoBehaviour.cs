using UnityEngine;
using Zenject;

public class GameRootMonoBehaviour : MonoBehaviour
{
    [Inject]
    private readonly GameRootGameScene game;

    void Start() => game.Start();
    void Update() => game.Update();

    // ���ې��E�ւ̓˓�! ���Ă��񂶂ł������悭�Ȃ��ł���

}
