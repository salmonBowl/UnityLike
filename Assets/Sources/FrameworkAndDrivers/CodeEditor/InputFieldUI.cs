using System;
using UnityEngine;
using TMPro;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.CodeManagement;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    [Serializable]
    public class InputFieldUI : ISetTextUI
    {
        public CodeEditorBlock block;

        public TMP_InputField inputField;
        public TextMeshProUGUI viewText;

        public CodeManager codeManager;

        public ErrorPopupUI errorPopupUI;

        private InputFieldUI()
        {
            codeManager = new CodeManager(this, errorPopupUI);
        }

        public void AttachmentInspection()
        {
            if (!inputField)
                Debug.LogError("inputFieldがアタッチされていません");
            if (!viewText)
                Debug.LogError("viewTextがアタッチされていません");
        }

        public void SetTextInputField(string text)
        {
            inputField.SetTextWithoutNotify(text); // WithoutNotifyが重要! ないと無限ループを起こします
        }

        public void SetViewText(string text)
        {
            viewText.text = text;
        }

        public void ShiftCaretPosition(int shiftCount)
        {
            inputField.caretPosition += shiftCount;
        }
    }
}
