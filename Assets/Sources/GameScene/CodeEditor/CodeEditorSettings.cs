using UnityEngine;

[CreateAssetMenu(fileName = "CpdeEditorSettings", menuName = "Scriptable Objects/CodeEditorSettings")]
public class CodeEditorSettings : ScriptableObject
{
    public float fontSize;
    
    [Header("1�s�ɂǂꂾ���̍������g�����w�肵�܂�")]
    public float lineHeight = 1.0f;

    [Header("InputField���ŏ��ł��ǂꂾ���̍����ɂȂ邩�w�肵�܂�")]
    public float lowerHeightInputField = 3.0f;

}