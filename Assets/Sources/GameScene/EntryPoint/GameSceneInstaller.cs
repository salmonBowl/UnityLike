using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [Header("ScriptableObject�t�@�C�����A�^�b�`���܂�")]
    [SerializeField]
    private CodeEditorSettings codeEditorSettings;

    [Space(20)]

    [Header("�J���Ɏg���S�ẴQ�[���I�u�W�F�N�g��R���|�[�l���g���擾���܂�")]

    [Header("CodeEditor�֌W")]
    [SerializeField] private RectTransform content;
    [SerializeField] private RectTransform blockVoidupdate;
    [SerializeField] private RectTransform areaVoidstart;
    [SerializeField] private RectTransform areaVoidupdate;

    // DI�R���e�i�Ɉˑ��֌W���o�C���h���܂�
    public override void InstallBindings()
    {
        // SerializeField�Ŏ擾�����R���|�[�l���g��o�^���܂�
        Container.Bind<CodeEditorSettings>().FromInstance(codeEditorSettings).AsSingle();
        Container.Bind<RectTransform>().WithId("content").FromInstance(content).AsSingle();
        Container.Bind<RectTransform>().WithId("blockVoidupdate").FromInstance(blockVoidupdate).AsSingle();
        Container.Bind<RectTransform>().WithId("areaVoidstart").FromInstance(areaVoidstart).AsSingle();
        Container.Bind<RectTransform>().WithId("areaVoidupdate").FromInstance(areaVoidupdate).AsSingle();

        // �ˑ��֌W���o�C���h���܂�
        Container.BindInterfacesAndSelfTo<GameRootGameScene>().AsSingle();
        Container.BindInterfacesAndSelfTo<CodeEditor>().AsSingle();
        Container.BindInterfacesAndSelfTo<CodeEditorLineCountManager>().AsSingle();
        Container.BindInterfacesAndSelfTo<CodeEditorTextAreaSize>().AsSingle();
    }
}
