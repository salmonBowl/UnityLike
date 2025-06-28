using UnityEngine;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.FrameworkAndDrivers.Settings
{
    [CreateAssetMenu(fileName = "CpdeEditorSettings", menuName = "Scriptable Objects/CodeEditorSettings")]
    public class CodeEditorSettings : ScriptableObject, ICodeEditorSettings
    {
        public float FontSize { get; } = 0.5f;

        [Header("1行にどれだけの高さを使うか指定します")]
        public float LineHeight { get; } = 0.72f;

        [Header("最後の行から表示範囲までの猶予を調整します")]
        public float AreaHeightOffset { get; } = 0.2f;

        [Header("InputFieldが最小でもどれだけの高さになるか指定します")]
        public float LowerHeightInputField { get; } = 3.0f;

    }
}