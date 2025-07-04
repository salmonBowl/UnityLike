using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Scriptable Object/InputFieldValidater", menuName = "InputFieldValidater", order = 0)]
public class InputFieldValidater : TMP_InputValidator
{
    /// <summary>
    /// InputField�̓��͕�����Custom�ɕύX���Ă��̃t�@�C���Őݒ肵�Ă��܂�
    /// ��̓I�ɂ�\����͂���ƃt�B�[���h��ɂ�\\������悤�ɂ��āA����n��v�Ȃǂ���͂��Ă��o�O���N���Ȃ��悤�ɂ��܂�
    /// </summary>
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (ch == '\\')
        {
            text = text.Insert(pos, "\\\\");
            pos += 2;

            return ch;
        }

        // �e�L�X�g���X�V
        text = text.Insert(pos, ch.ToString());
        // �ʒu���ړ�
        pos++;

        return ch;
    }
}
