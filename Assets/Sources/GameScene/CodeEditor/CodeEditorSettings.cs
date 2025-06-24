using UnityEngine;

[CreateAssetMenu(fileName = "CpdeEditorSettings", menuName = "ScriptableObject/CodeEditorSettings")]
public class CodeEditorSettings : ScriptableObject
{
    [SerializeField] float fontSize;
    [SerializeField] float lineHeight;
    [SerializeField] float minimumLineCount;
}