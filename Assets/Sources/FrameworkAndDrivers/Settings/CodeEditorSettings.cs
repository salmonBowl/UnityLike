using UnityEngine;

using UnityLike.Entities.Shared;

namespace UnityLike.FrameworkAndDrivers.Settings
{
    [CreateAssetMenu(fileName = "CodeEditorSettings", menuName = "Scriptable Objects/CodeEditorSettings")]
    public class CodeEditorSettings : ScriptableObject, ICodeEditorSettings
    {
        public float FontSize { get; set; } = 0.5f;

        [Header("1�s�ɂǂꂾ���̍������g�����w�肵�܂�")]
        public float LineHeight { get; set; } = 0.72f;

        [Header("�Ō�̍s����\���͈͂܂ł̗P�\�𒲐����܂�")]
        public float AreaHeightOffset { get; set; } = 0.2f;

        [Header("InputField���ŏ��ł��ǂꂾ���̍����ɂȂ邩�w�肵�܂�")]
        public float LowerHeightInputField { get; } = 3.0f;

    }
}