using System;

using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public interface ICompilerPresenter
    {
        public void SetViewText(CodeEditorBlock block, string text);
    }
}