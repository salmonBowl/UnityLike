using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [Header("ScriptableObjectファイルをアタッチします")]
    [SerializeField]
    private CodeEditorSettings codeEditorSettings;

    [Space(20)]

    [Header("開発に使う全てのMonoBehaviourクラスを取得します")]

    [Header("CodeEditor関係")]
    [SerializeField]
    private CodeEditorTextAreaView codeEditorTextAreaView;

    public override void Start()
    {
        base.Start();

        if (codeEditorSettings == null)
            Debug.LogError("GameSceneInstaller : CodeEditorSettingsが指定されていません");
        if (codeEditorTextAreaView == null)
            Debug.LogError("GameSceneInstaller : CodeEditorTextAreaViewが指定されていません");
    }

    // DIコンテナに依存関係をバインドします
    public override void InstallBindings()
    {
        // Entities層
        Container.Bind<CodeEditorSettings>().FromInstance(codeEditorSettings).AsSingle();
        // TextAreaLayoutDataはUseCaseが直接生成

        // Use Cases層
        Container.Bind<CodeEditorLineCountManager>().AsSingle();
        Container.Bind<UpdateTextAreaUseCase>().AsSingle();

        // Interface Adapters層
        Container.Bind<ITextAreaLayoutPresenter>().To<TextAreaLayoutPresenter>().AsSingle();
        Container.Bind<ITextAreaView>().FromInstance(codeEditorTextAreaView).AsSingle(); // MonoBehaviourをインターフェースとしてバインド

        // 全体のシステム
        Container.Bind<CodeEditor>().AsSingle();
        Container.Bind<GameRootGameScene>().AsSingle().NonLazy();
    }
}
