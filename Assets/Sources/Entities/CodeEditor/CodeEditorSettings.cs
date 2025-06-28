using UnityEngine;

[CreateAssetMenu(fileName = "CpdeEditorSettings", menuName = "Scriptable Objects/CodeEditorSettings")]
public class CodeEditorSettings : ScriptableObject
{
    public float FontSize = 0.5f;
    
    [Header("1�s�ɂǂꂾ���̍������g�����w�肵�܂�")]
    public float LineHeight = 0.72f;

    [Header("�Ō�̍s����\���͈͂܂ł̗P�\�𒲐����܂�")]
    public float AreaHeightOffset = 0.2f;

    [Header("InputField���ŏ��ł��ǂꂾ���̍����ɂȂ邩�w�肵�܂�")]
    public float LowerHeightInputField = 3.0f;

}