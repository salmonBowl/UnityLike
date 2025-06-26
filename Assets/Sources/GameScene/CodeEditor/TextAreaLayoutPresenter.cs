using UnityEngine;
using Zenject;

public interface ITextAreaView
{
    // �eRectTransform�̃T�C�Y�ƈʒu��ݒ肷�郁�\�b�h
    void SetContentSize(Vector2 size);
    void SetAreaVoidstartLayout(Vector2 size, Vector2 anchoredPosition);
    void SetAreaVoidupdateLayout(Vector2 size, Vector2 anchoredPosition);
    void SetBlockVoidupdatePosition(Vector2 anchoredPosition);

    float GetContentWidth();
}

public class TextAreaLayoutPresenter : ITextAreaLayoutPresenter
{
    private readonly ITextAreaView view;

    [Inject]
    public TextAreaLayoutPresenter(ITextAreaView view)
    {
        this.view = view;
    }

    public void PresenterLayout(TextAreaLayoutData layoutData)
    {
        if (view == null)
        {
            UnityEngine.Debug.LogError("TextAreaLayoutPresenter : view���w�肳��Ă��܂���");
            return;
        }

        view.SetContentSize(new Vector2(view.GetContentWidth(), layoutData.ContentHeight));

        view.SetAreaVoidstartLayout(layoutData.AreaVoidstartSize, layoutData.AreaVoidstartPosition);

        view.SetAreaVoidupdateLayout(layoutData.AreaVoidupdateSize, layoutData.AreaVoidupdatePosition);

        view.SetBlockVoidupdatePosition(layoutData.BlockVoidupdatePosition);
    }
}