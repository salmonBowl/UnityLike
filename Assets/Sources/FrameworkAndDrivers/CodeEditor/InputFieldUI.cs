using System;
using UnityEngine;
using TMPro;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.CodeEditorInputController;
using UnityLike.InterfaceAdapters.TextAreaLayout;
using UnityLike.InterfaceAdapters.CompileManagement;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class InputFieldUI : MonoBehaviour, ITextAreaInput, IGetInputFieldText, ISetTextUI
    {
        [SerializeField]
        private TMP_InputField inputField;
        [SerializeField]
        private TextMeshProUGUI viewText;

        public event Action<CodeEditorBlock, string> OnTextChanged;

        public string GetInputFieldText()
        {
            if (!inputField)
            {
                Debug.LogError("inputFieldVoidstartがアタッチされていません");
                return "";
            }
            return inputField.text;
        }

        public void SetTextInputField(string text)
        {
            if (!inputField)
            {
                Debug.LogError("inputFieldVoidstartがアタッチされていません");
                return;
            }
            inputField.SetTextWithoutNotify(text); // WithoutNotifyが重要! ないと無限ループを起こします
        }

        public void SetViewText(string text)
        {
            if (!viewText)
            {
                Debug.LogError("viewTextVoidstartがアタッチされていません");
                return;
            }
            viewText.text = text;
        }

        public void ShiftCaretPosition(int shiftCount)
        {
            if (!inputField)
            {
                Debug.LogError("inputFieldVoidstartがアタッチされていません");
                return;
            }
            Debug.Log("currentCaretPosition : " + inputField.caretPosition);
            inputField.caretPosition += shiftCount;
        }

        public void OnAreaVoidstartTextChanged(string newText)
        {
            OnTextChanged?.Invoke(CodeEditorBlock.VoidStart, newText);
        }
    }
}
