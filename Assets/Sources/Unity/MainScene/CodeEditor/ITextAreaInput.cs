using System;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Controller
{
    public interface ITextAreaInput
    {
        event Action<CodeEditorBlock, string> OnTextAreaInputChanged;
    }
}