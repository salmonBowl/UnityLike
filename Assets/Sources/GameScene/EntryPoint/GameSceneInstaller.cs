using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [Header("ScriptableObject�t�@�C�����A�^�b�`���܂�")]
    [SerializeField]
    private CodeEditorSettings codeEditorSettings;

    [Space(20)]

    [Header("�J���Ɏg���S�Ă�MonoBehaviour�N���X���擾���܂�")]

    [Header("CodeEditor�֌W")]
    [SerializeField]
    private CodeEditorTextAreaView codeEditorTextAreaView;

    public override void Start()
    {
        base.Start();

        if (codeEditorSettings == null)
            Debug.LogError("GameSceneInstaller : CodeEditorSettings���w�肳��Ă��܂���");
        if (codeEditorTextAreaView == null)
            Debug.LogError("GameSceneInstaller : CodeEditorTextAreaView���w�肳��Ă��܂���");
    }

    // DI�R���e�i�Ɉˑ��֌W���o�C���h���܂�
    public override void InstallBindings()
    {
        // Entities�w
        Container.Bind<CodeEditorSettings>().FromInstance(codeEditorSettings).AsSingle();
        // TextAreaLayoutData��UseCase�����ڐ���

        // Use Cases�w
        Container.Bind<CodeEditorLineCountManager>().AsSingle();
        Container.Bind<UpdateTextAreaUseCase>().AsSingle();

        // Interface Adapters�w
        Container.Bind<ITextAreaLayoutPresenter>().To<TextAreaLayoutPresenter>().AsSingle();
        Container.Bind<ITextAreaView>().FromInstance(codeEditorTextAreaView).AsSingle(); // MonoBehaviour���C���^�[�t�F�[�X�Ƃ��ăo�C���h

        // �S�̂̃V�X�e��
        Container.Bind<CodeEditor>().AsSingle();
        Container.Bind<GameRootGameScene>().AsSingle().NonLazy();
    }
}
