using UnityEngine;
using Zenject;

// Entities層
using UnityLike.Entities.Shared;

// UseCases層

// InterfaceAdapter層
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
        public static CodeEditorSettings CodeEditorSettings;

        [Space(20)]

        [Header("開発に使う全てのMonoBehaviourクラスをアタッチします")]

        [Header("CodeEditor関係")]
        [SerializeField]
        private CodeEditor.CodeEditor codeEditorLayout;
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

            CodeEditorSettings = codeEditorSettings;
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
            Container.Bind<LayoutDataBuilder>().AsSingle();

            /*
             *  --- Interface Adapters層 ---
             */


            //

            /*
             *  --- Frameworks & Drivers層 ---
             */

            // MonoBehaviourをインターフェースとしてバインド
            Container.Bind<ITextAreaView>().FromInstance(codeEditorLayout).AsSingle();



            /*
             *  --- 使用されていないクラス ---
             *  ただしそれを持つクラスでメンバーnullを出さないためにバインドしています
             */

            //Container.Bind<CodeEditor>().AsSingle();

        }
    }
}
