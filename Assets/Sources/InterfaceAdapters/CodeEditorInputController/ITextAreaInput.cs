using System;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.CodeEditorInputController
{
    public interface ITextAreaInput
    {
        event Action<CodeEditorBlock, string> OnTextAreaInputChanged;
    }
}