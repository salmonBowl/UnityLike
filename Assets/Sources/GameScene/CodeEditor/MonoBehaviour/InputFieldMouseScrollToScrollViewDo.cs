using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ScrollView�̎q�ɂȂ��Ă���InputField�ɃA�^�b�`���܂�
/// </summary>
public class InputFieldMouseScrollToScrollViewDo : MonoBehaviour, IScrollHandler
{
    [SerializeField] ScrollRect parentScrollView;

    void Start()
    {
        if (parentScrollView == null)
            Debug.LogError("InputField.IFMSTSVD : parentScrollView���A�^�b�`����Ă��܂���");
    }

    /// <summary>
    /// InputField��ŃX�N���[��������������Ăяo����܂�
    /// </summary>
    /// <param name="e">InputField�̃C�x���g�f�[�^</param>
    public void OnScroll(PointerEventData e)
    {
        //Debug.Log("InputField Scrolled");

        // �e��ScrollView�ɃC�x���g��n���܂�
        ExecuteEvents.Execute(parentScrollView.gameObject, e, ExecuteEvents.scrollHandler);

        // InputField�̃X�N���[���𖳌���
        e.Use();
    }
}
