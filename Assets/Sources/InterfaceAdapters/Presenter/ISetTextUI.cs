using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public interface ISetTextUI
    {
        void SetTextInputField(CodeEditorBlock block, string text);
        void SetViewText(CodeEditorBlock block, string text);
        void ShiftCaretPosition(CodeEditorBlock block, int shiftCount);
    }
}