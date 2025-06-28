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
        [Header("1行にどれだけの高さを使うか指定します")]
        public float LineHeight { get; private set; } = 0.72f;

        [field: SerializeField]
        [Header("最後の行から表示範囲までの猶予を調整します")]
        public float AreaHeightOffset { get; private set; } = 0.2f;

        [field: SerializeField]
        [Header("InputFieldが最小でもどれだけの高さになるか指定します")]
        public float LowerHeightInputField { get; private set; } = 3.0f;

    }
}