using System.ComponentModel;
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
    private CodeEditorTextAreaUI codeEditorTextAreaView;

    public override void Start()
    {
        //base.Start(); 空メソッド

        if (codeEditorSettings == null)
            Debug.LogError("GameSceneInstaller : CodeEditorSettingsが指定されていません");
        if (codeEditorTextAreaView == null)
            Debug.LogError("GameSceneInstaller : CodeEditorTextAreaViewが指定されていません");
    }

    // DIコンテナに依存関係をバインドします
    public override void InstallBindings()
    {
        Debug.Log("GameSceneInstaller.InstallBindings()");

        // Entities層
        Container.Bind<CodeEditorSettings>().FromInstance(codeEditorSettings).AsSingle();
        // TextAreaLayoutDataはUseCaseが直接生成

        // Use Cases層
        Container.Bind<CodeEditorLineCountManager>().AsSingle();
        Container.Bind<UpdateTextAreaUseCase>().AsSingle();

        // Interface Adapters層
        Container.Bind<ITextAreaLayoutPresenter>().To<TextAreaLayoutPresenter>().AsSingle();
        Container.Bind<ITextAreaView>().FromInstance(codeEditorTextAreaView).AsSingle(); // MonoBehaviourをインターフェースとしてバインド
        Container.Bind<ITextAreaInput>().FromInstance(codeEditorTextAreaView).AsSingle();
        Container.BindInterfacesAndSelfTo<Greeter>()
           .FromSubContainerResolve().ByMethod(KernelInstaller).AsSingle().NonLazy();

        // 全体のシステム
        Container.Bind<CodeEditor>().AsSingle();
        Container.Bind<GameRootGameScene>().AsSingle();
    }
    private void KernelInstaller(DiContainer subContainer)
    {
        subContainer.Bind<Greeter>().AsSingle();

        subContainer.Bind<CodeEditorInputController>().AsSingle().NonLazy(); // 疎結合になりすぎて誰もこれのインスタンスを持たない
    }
}
public class Greeter : Kernel
{
    public Greeter() => Debug.Log("Create Greeter!");
}
