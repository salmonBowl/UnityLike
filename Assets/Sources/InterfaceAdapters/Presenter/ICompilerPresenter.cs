using System;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public interface ICompilerPresenter
    {
        public event Action<CodeEditorBlock, string> OnCompiled;
    }
}