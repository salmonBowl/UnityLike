using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public interface ISyntaxTextView
    {
        void SetViewText(CodeEditorBlock block, string text);
    }
}