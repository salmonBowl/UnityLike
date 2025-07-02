using UnityEngine;
using Zenject;

// Entities�w��using
// ���������̑w���C���X�^���X�Ƃ��Ďg���邱�Ƃ͊�{�Ȃ�
using UnityLike.Entities.Shared;

// UseCases�w��using
using UnityLike.UseCases.CodeEditor;

// InterfaceAdapter�w��using
using UnityLike.InterfaceAdapters.Presenter;
using UnityLike.InterfaceAdapters.Controller;

// FramewoekAndDrivers�w��using
using UnityLike.FrameworkAndDrivers.CodeEditor;
using UnityLike.FrameworkAndDrivers.Settings;

namespace UnityLike.FrameworkAndDrivers.Installers
{
    public class GameSceneInstaller : MonoInstaller
    {
        [Header("ScriptableObject�t�@�C�����A�^�b�`���܂�")]
        [SerializeField]
        private CodeEditorSettings codeEditorSettings;

        [Space(20)]

        [Header("�J���Ɏg���S�Ă�MonoBehaviour�N���X���擾���܂�")]

        [Header("CodeEditor�֌W")]
        [SerializeField]
        private TextAreaUI codeEditorTextAreaView;

        public override void Start()
        {
            //base.Start(); �󃁃\�b�h

            if (codeEditorSettings == null)
                Debug.LogError("GameSceneInstaller : CodeEditorSettings���w�肳��Ă��܂���");
            if (codeEditorTextAreaView == null)
                Debug.LogError("GameSceneInstaller : CodeEditorTextAreaView���w�肳��Ă��܂���");
        }

        // DI�R���e�i�Ɉˑ��֌W���o�C���h���܂�
        public override void InstallBindings()
        {
            Debug.Log("GameSceneInstaller.InstallBindings()");

            /*
             *  --- Entities�w --
             */

            // ScriptableObject
            Container.Bind<ICodeEditorSettings>().FromInstance(codeEditorSettings).AsSingle();

            /*
             *  --- Use Cases�w ---
             */

            Container.Bind<LineCountManager>().AsSingle();
            Container.Bind<UpdateTextAreaUseCase>().AsSingle();

            /*
             *  --- Interface Adapters�w ---
             */

            Container.Bind<ITextAreaLayoutPresenter>().To<TextAreaLayoutPresenter>().AsSingle();

            //

            /*
             *  --- Frameworks & Drivers�w ---
             */

            // MonoBehaviour���C���^�[�t�F�[�X�Ƃ��ăo�C���h
            Container.Bind<ITextAreaView>().FromInstance(codeEditorTextAreaView).AsSingle();
            Container.Bind<ITextAreaInput>().FromInstance(codeEditorTextAreaView).AsSingle();
            Container.Bind<IGetInputFieldText>().FromInstance(codeEditorTextAreaView).AsSingle();
            Container.Bind<ISetTextUI>().FromInstance(codeEditorTextAreaView).AsSingle();

            // �G���g���[�|�C���g
            Container.Bind<GameRootGameScene>().AsSingle();


            /*
             *  --- Kernel�̃o�C���h ---
             */

            Container.BindInterfacesAndSelfTo<Kernel>().FromSubContainerResolve().ByMethod(KernelInstaller).AsSingle();


            /*
             *  --- �g�p����Ă��Ȃ��N���X ---
             *  ��������������N���X�Ń����o�[null���o���Ȃ����߂Ƀo�C���h���Ă��܂�
             */

            //Container.Bind<CodeEditor>().AsSingle();

        }
        private void KernelInstaller(DiContainer subContainer)
        {
            subContainer.Bind<Kernel>().AsSingle();

            // Initialize()�Ȃǂ̃��\�b�h���g�p����N���X��Kernel���o�C���h���܂�


            /*
             *  --- Use Cases�w ---
             */

            /*
             *  --- Interface Adapters�w ---
             */

            subContainer.BindInterfacesTo<CodeEditorInputController>().AsSingle().NonLazy();

            subContainer.Bind<ICodeChangeInputPort>().To<CompilerPresenter>().AsSingle();

            /*
             *  --- Frameworks & Drivers�w ---
             */


        }
    }
}
