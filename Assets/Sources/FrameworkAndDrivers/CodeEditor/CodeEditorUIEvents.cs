using System;
using UnityEngine;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.CodeEditorInputManagement;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class CodeEditorUIEvents : MonoBehaviour
    {
        private CodeEditorInputManager inputManager;
        
        public void SetInputManager(CodeEditorInputManager inputManager)
        {
            this.inputManager = inputManager;
        }

        public void OnCodeChangedVoidstart(string newText)
        {
            inputManager.OnTextChanged(CodeEditorBlock.VoidStart, newText);
        }
        public void OnCodeChangedVoidupdate(string newText)
        {
            inputManager.OnTextChanged(CodeEditorBlock.VoidUpdate, newText);
        }
    }
}