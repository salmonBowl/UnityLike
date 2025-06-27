using UnityEngine;

[CreateAssetMenu(fileName = "CpdeEditorSettings", menuName = "Scriptable Objects/CodeEditorSettings")]
public class CodeEditorSettings : ScriptableObject
{
    public float FontSize = 0.5f;
    
    [Header("1行にどれだけの高さを使うか指定します")]
    public float LineHeight = 0.72f;

    [Header("最後の行から表示範囲までの猶予を調整します")]
    public float AreaHeightOffset = 0.2f;

    [Header("InputFieldが最小でもどれだけの高さになるか指定します")]
    public float LowerHeightInputField = 3.0f;

}