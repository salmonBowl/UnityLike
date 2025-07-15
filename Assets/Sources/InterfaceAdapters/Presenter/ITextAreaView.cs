using Vector2 = UnityEngine.Vector2;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public interface ITextAreaView
    {
        // �eRectTransform�̃T�C�Y�ƈʒu��ݒ肷�郁�\�b�h
        void SetContentSize(Vector2 anchoredSize);
        void SetAreaVoidstartLayout(Vector2 size, Vector2 anchoredPosition);
        void SetAreaVoidupdateLayout(Vector2 size, Vector2 anchoredPosition);
        void SetBlockVoidupdatePosition(Vector2 anchoredPosition);

        float GetContentWidth();
    }
}