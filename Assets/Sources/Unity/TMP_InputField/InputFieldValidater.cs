using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "Scriptable Object/InputFieldValidater", menuName = "InputFieldValidater", order = 0)]
public class InputFieldValidater : TMP_InputValidator
{
    /// <summary>
    /// InputFieldの入力方式をCustomに変更してこのファイルで設定しています
    /// 具体的には\を入力するとフィールド上には\\が入るようにして、次にnやvなどを入力してもバグが起きないようにします
    /// </summary>
    public override char Validate(ref string text, ref int pos, char ch)
    {
        if (ch == '\\')
        {
            text = text.Insert(pos, "\\\\");
            pos += 2;

            return ch;
        }

        // テキストを更新
        text = text.Insert(pos, ch.ToString());
        // 位置を移動
        pos++;

        return ch;
    }
}
