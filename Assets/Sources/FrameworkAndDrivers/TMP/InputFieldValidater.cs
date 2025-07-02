using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "TMPro/InputFieldValidater", menuName = "InputFieldValidater")]
public class InputFieldValidater : TMP_InputValidator
{
    /// <summary>
    /// 
    /// </summary>
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (ch == '\\')
        {
            text += "\\\\";
            pos++;

            return ch;
        }

        // �e�L�X�g���X�V
        text += ch;
        // �ʒu���ړ�
        pos++;

        return ch;
    }
}
