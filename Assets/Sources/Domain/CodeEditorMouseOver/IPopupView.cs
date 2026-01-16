
namespace UnityLike.InterfaceAdapters.CodeEditorMouseOver
{
    public interface IPopupView
    {
        void HidePopup();
        void ShowPopup();
        void SetText(string message);
    }
}