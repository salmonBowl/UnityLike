using UnityEngine;
using Zenject;

// Entities層のusing
// ただしこの層がインスタンスとして使われることは基本ない
using UnityLike.Entities.Shared;

// UseCases層のusing
using UnityLike.UseCases.CodeEditor;

// InterfaceAdapter層のusing
using UnityLike.InterfaceAdapters.Presenter;
using UnityLike.InterfaceAdapters.Controller;

// FramewoekAndDrivers層のusing
using UnityLike.FrameworkAndDrivers.CodeEditor;
using UnityLike.FrameworkAndDrivers.Settings;

namespace UnityLike.FrameworkAndDrivers.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [Header("ScriptableObjectファイルをアタッチします")]
        [SerializeField]
        private CodeEditorSettings codeEditorSettings;

        [Space(20)]

        [Header("開発に使う全てのMonoBehaviourクラスを取得します")]

        [Header("CodeEditor関係")]
        [SerializeField]
        private TextAreaUI codeEditorTextAreaView;

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

            /*
             *  --- Entities層 --
             */

            // ScriptableObject
            Container.Bind<ICodeEditorSettings>().FromInstance(codeEditorSettings).AsSingle();

            /*
             *  --- Use Cases層 ---
             */

            Container.Bind<LineCountManager>().AsSingle();
            Container.Bind<UpdateTextAreaUseCase>().AsSingle();

            /*
             *  --- Interface Adapters層 ---
             */

            Container.Bind<ITextAreaLayoutPresenter>().To<TextAreaLayoutPresenter>().AsSingle();

            //

            /*
             *  --- Frameworks & Drivers層 ---
             */

            // MonoBehaviourをインターフェースとしてバインド
            Container.Bind<ITextAreaView>().FromInstance(codeEditorTextAreaView).AsSingle();
            Container.Bind<ITextAreaInput>().FromInstance(codeEditorTextAreaView).AsSingle();
            Container.Bind<IGetInputFieldText>().FromInstance(codeEditorTextAreaView).AsSingle();
            Container.Bind<ISetTextUI>().FromInstance(codeEditorTextAreaView).AsSingle();

            // エントリーポイント
            Container.Bind<GameRootGameScene>().AsSingle();


            /*
             *  --- Kernelのバインド ---
             */

            Container.BindInterfacesAndSelfTo<Kernel>().FromSubContainerResolve().ByMethod(KernelInstaller).AsSingle();


            /*
             *  --- 使用されていないクラス ---
             *  ただしそれを持つクラスでメンバーnullを出さないためにバインドしています
             */

            //Container.Bind<CodeEditor>().AsSingle();

        }
        private void KernelInstaller(DiContainer subContainer)
        {
            subContainer.Bind<Kernel>().AsSingle();

            // Initialize()などのメソッドを使用するクラスでKernelをバインドします


            /*
             *  --- Use Cases層 ---
             */

            /*
             *  --- Interface Adapters層 ---
             */

            subContainer.BindInterfacesTo<CodeEditorInputController>().AsSingle().NonLazy();

            subContainer.Bind<ICodeChangeInputPort>().To<CompilerPresenter>().AsSingle();

            /*
             *  --- Frameworks & Drivers層 ---
             */


        }
    }
}
