using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.CompileManagement
{
    public interface ISetTextUI
    {
        void SetTextInputField(string text);
        void SetViewText(string text);
        void ShiftCaretPosition(int shiftCount);
    }
}