using UnityEngine;
using Zenject;

// Entities層
using UnityLike.Entities.Shared;

// UseCases層
using UnityLike.UseCases.CodeEditor;

// InterfaceAdapter層
using UnityLike.InterfaceAdapters.CodeEditorInputController;
using UnityLike.InterfaceAdapters.CodeManagement;
using UnityLike.InterfaceAdapters.TextAreaLayout;

// FramewoekAndDrivers層
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

        [Header("開発に使う全てのMonoBehaviourクラスをアタッチします")]

        [Header("CodeEditor関係")]
        [SerializeField]
        private CodeEditorLayout codeEditorLayout;
        [SerializeField]
        private CodeEditorUIEvents codeEditorUIEvents;

        public override void Start()
        {
            //base.Start(); 空メソッド

            if (!codeEditorSettings)
                Debug.LogError("GameSceneInstaller : CodeEditorSettingsが指定されていません");
            if (!codeEditorLayout)
                Debug.LogError("GameSceneInstaller : CodeEditorLayoutがアタッチされていません");
            if (!codeEditorUIEvents)
                Debug.LogError("GameSceneInstaller : CodeEditorUIEventsがアタッチされていません");
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

            Container.Bind<ITextAreaLayoutAdapter>().To<TextAreaLayoutAdapter>().AsSingle();

            //

            /*
             *  --- Frameworks & Drivers層 ---
             */

            // MonoBehaviourをインターフェースとしてバインド
            Container.Bind<ITextAreaView>().FromInstance(codeEditorLayout).AsSingle();
            Container.Bind<ITextAreaInput>().FromInstance(codeEditorUIEvents).AsSingle();

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

            subContainer.Bind<ICodeChangeInputPort>().To<CodeManager>().AsSingle();

            /*
             *  --- Frameworks & Drivers層 ---
             */


        }
    }
}
