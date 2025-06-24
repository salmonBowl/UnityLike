using UnityEngine;

[CreateAssetMenu(fileName = "CpdeEditorSettings", menuName = "ScriptableObject/CodeEditorSettings")]
public class CodeEditorSettings : ScriptableObject
{
    public float fontSize;
    
    [Header("1行にどれだけの高さを使うか指定します")]
    public float lineHeight;

    [Header("InputFieldが最小でもどれだけの高さになるか指定します")]
    public float lowerHeightInputField = 3.0f;

}