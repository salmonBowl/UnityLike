using UnityEngine;

public class GetComponentAllGameScene : MonoBehaviour
{
    private GameRootGameScene game;

    [Header("ScriptableObjectファイルをアタッチします")]
    [SerializeField]
    private CodeEditorSettings codeEditorSettings;

    [Header("開発に使う全てのゲームオブジェクトやコンポーネントを取得します")]

    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private RectTransform areaVoidstart;
    [SerializeField]
    private RectTransform blockVoidupdate;
    [SerializeField]
    private RectTransform areaVoidupdate;



    void Start()
    {
        game = new(
            codeEditorSettings,
            content,
            areaVoidstart,
            blockVoidupdate,
            areaVoidupdate
            );
    }

    void Update() => game.Update();

    // 抽象世界への突入! ってかんじでかっこよくないですか

}
