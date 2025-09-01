using UnityEngine;
using Zenject;

// Entities層
using UnityLike.Entities.GameRoop;

// UseCases層

// InterfaceAdapter層

// FramewoekAndDrivers層
using UnityLike.FrameworkAndDrivers.CodeEditor;
using UnityLike.FrameworkAndDrivers.Settings;
using UnityLike.FrameworkAndDrivers.GameRoop;

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
        private CodeEditorUIEvents codeEditorUIEvents;

        [Header("UI関係")]
        [SerializeField]
        private GameRoopExecuter gameRoopExecuter;
        [SerializeField]
        private WhilePlayingEffect whilePlayingEffect;

        public void Awake()
        {
            CodeEditorSettings = codeEditorSettings;
        }
        public override void Start()
        {
            //base.Start(); 空メソッド

            if (!codeEditorSettings)
                Debug.LogError("GameSceneInstaller : CodeEditorSettingsが指定されていません");
            if (!codeEditorUIEvents)
                Debug.LogError("GameSceneInstaller : CodeEditorUIEventsがアタッチされていません");
        }

        // DIコンテナに依存関係をバインドします
        public override void InstallBindings()
        {
            Debug.Log("GameSceneInstaller.InstallBindings()");


            /*
             *  --- 使用されていないクラス ---
             *  ただしそれを持つクラスでメンバーnullを出さないためにバインドしています
             */

            //Container.Bind<CodeEditor>().AsSingle();

        }
    }
}
