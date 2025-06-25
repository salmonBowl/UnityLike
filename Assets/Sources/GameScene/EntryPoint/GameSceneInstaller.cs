using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [Header("ScriptableObjectファイルをアタッチします")]
    [SerializeField]
    private CodeEditorSettings codeEditorSettings;

    [Space(20)]

    [Header("開発に使う全てのゲームオブジェクトやコンポーネントを取得します")]

    [Header("CodeEditor関係")]
    [SerializeField] private RectTransform content;
    [SerializeField] private RectTransform blockVoidupdate;
    [SerializeField] private RectTransform areaVoidstart;
    [SerializeField] private RectTransform areaVoidupdate;

    // DIコンテナに依存関係をバインドします
    public override void InstallBindings()
    {
        // SerializeFieldで取得したコンポーネントを登録します
        Container.Bind<CodeEditorSettings>().FromInstance(codeEditorSettings).AsSingle();
        Container.Bind<RectTransform>().WithId("content").FromInstance(content).AsSingle();
        Container.Bind<RectTransform>().WithId("blockVoidupdate").FromInstance(blockVoidupdate).AsSingle();
        Container.Bind<RectTransform>().WithId("areaVoidstart").FromInstance(areaVoidstart).AsSingle();
        Container.Bind<RectTransform>().WithId("areaVoidupdate").FromInstance(areaVoidupdate).AsSingle();

        // 依存関係をバインドします
        Container.BindInterfacesAndSelfTo<GameRootGameScene>().AsSingle();
        Container.BindInterfacesAndSelfTo<CodeEditor>().AsSingle();
        Container.BindInterfacesAndSelfTo<CodeEditorLineCountManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<CodeEditorTextAreaSize>().AsSingle();
    }
}
