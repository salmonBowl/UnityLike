using UnityEngine;
using Zenject;

// Entities層のusing
using UnityLike.Entities.CodeEditor;
//using UnityLike.Entities.;

// UseCases層のusing
using UnityLike.UseCases.CodeEditor;

// InterfaceAdapter層のusing
using UnityLike.InterfaceAdapter.Presenter;
using UnityLike.InterfaceAdapter.Controller;

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

            Container.Bind<CodeEditor>().AsSingle();

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

            subContainer.BindInterfacesTo<InputController>().AsSingle().NonLazy();

            /*
             *  --- Frameworks & Drivers層 ---
             */


        }
    }
}
