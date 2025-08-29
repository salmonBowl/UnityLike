
namespace UnityLike.InterfaceAdapters.CodeManagement
{
    public interface ISetTextUI
    {
        void SetTextInputField(string text);
        void SetViewText(string text);
        void ShiftCaretPosition(int shiftCount);
    }
}