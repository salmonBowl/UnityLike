using UnityEngine;

public class GetComponentAllGameScene : MonoBehaviour
{
    private GameRootGameScene game;

    [Header("ScriptableObject�t�@�C�����A�^�b�`���܂�")]
    [SerializeField]
    private CodeEditorSettings codeEditorSettings;

    [Header("�J���Ɏg���S�ẴQ�[���I�u�W�F�N�g��R���|�[�l���g���擾���܂�")]

    [SerializeField]
    private RectTransform content;
    [SerializeField]
    private RectTransform areaVoidstart;
    [SerializeField]
    private RectTransform blockVoidupdate;
    [SerializeField]
    private RectTransform areaVoidupdate;



    void Start()
    {
        game = new(
            codeEditorSettings,
            content,
            areaVoidstart,
            blockVoidupdate,
            areaVoidupdate
            );
    }

    void Update() => game.Update();

    // ���ې��E�ւ̓˓�! ���Ă��񂶂ł������悭�Ȃ��ł���

}
