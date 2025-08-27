using System;
using UnityEngine;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.CodeEditorInputController;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class CodeEditorUIEvents : MonoBehaviour, ITextAreaInput
    {
        public event Action<CodeEditorBlock, string> OnCodeChanged;

        public void OnCodeChangedVoidstart(string newText)
        {
            OnCodeChanged?.Invoke(CodeEditorBlock.VoidStart, newText);
        }
        public void OnCodeChangedVoidupdate(string newText)
        {
            OnCodeChanged?.Invoke(CodeEditorBlock.VoidUpdate, newText);
        }
    }
}