using UnityEngine;

using UnityLike.Entities.Shared;

namespace UnityLike.FrameworkAndDrivers.Settings
{
    [CreateAssetMenu(fileName = "CodeEditorSettings", menuName = "Scriptable Objects/CodeEditorSettings")]
    public class CodeEditorSettings : ScriptableObject, ICodeEditorSettings
    {
        [field: SerializeField]
        public float FontSize { get; private set; } = 0.5f;

        [field: SerializeField]
        [Header("1�s�ɂǂꂾ���̍������g�����w�肵�܂�")]
        public float LineHeight { get; private set; } = 0.72f;

        [field: SerializeField]
        [Header("�Ō�̍s����\���͈͂܂ł̗P�\�𒲐����܂�")]
        public float AreaHeightOffset { get; private set; } = 0.2f;

        [field: SerializeField]
        [Header("InputField���ŏ��ł��ǂꂾ���̍����ɂȂ邩�w�肵�܂�")]
        public float LowerHeightInputField { get; private set; } = 3.0f;

    }
}