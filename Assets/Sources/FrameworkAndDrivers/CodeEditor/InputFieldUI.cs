using System;
using UnityEngine;
using TMPro;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.CodeManagement;
using System.Globalization;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    [Serializable]
    public class InputFieldUI : ISetTextUI
    {
        public CodeEditorBlock block;

        public TMP_InputField inputField; private TMP_Text inputFieldText;
        public TextMeshProUGUI viewText;

        public CodeManager codeManager;

        public ErrorPopupUI errorPopupUI;
        public IUIPosCalculator mousePos;

        public void MemberInitialize()
        {
            codeManager = new CodeManager(this, errorPopupUI);
            inputFieldText = inputField.textComponent;
        }
        public void DIMousePos(IUIPosCalculator mousePos)
        {
            this.mousePos = mousePos;
        }

        public void ExecuteCode() => codeManager.ExecuteCode();

        public void Update()
        {
            PopupRequire();
        }
        public void HidePopup()
        {
            errorPopupUI.HidePopup();
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

        public string GetInputFieldText()
        {
            return inputField.text;
        }

        private void PopupRequire()
        {
            Vector2Int textPos = mousePos.GetTextPosOnMouse(inputFieldText);
            codeManager.PopupRequired(textPos);
        }
    }
}
