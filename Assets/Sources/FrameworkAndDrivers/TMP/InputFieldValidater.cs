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

        // テキストを更新
        text += ch;
        // 位置を移動
        pos++;

        return ch;
    }
}
