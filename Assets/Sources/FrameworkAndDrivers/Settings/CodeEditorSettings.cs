using UnityEngine;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.FrameworkAndDrivers.Settings
{
    [CreateAssetMenu(fileName = "CpdeEditorSettings", menuName = "Scriptable Objects/CodeEditorSettings")]
    public class CodeEditorSettings : ScriptableObject, ICodeEditorSettings
    {
        public float FontSize { get; } = 0.5f;

        [Header("1�s�ɂǂꂾ���̍������g�����w�肵�܂�")]
        public float LineHeight { get; } = 0.72f;

        [Header("�Ō�̍s����\���͈͂܂ł̗P�\�𒲐����܂�")]
        public float AreaHeightOffset { get; } = 0.2f;

        [Header("InputField���ŏ��ł��ǂꂾ���̍����ɂȂ邩�w�肵�܂�")]
        public float LowerHeightInputField { get; } = 3.0f;

    }
}