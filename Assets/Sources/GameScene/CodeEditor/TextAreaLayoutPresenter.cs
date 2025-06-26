using UnityEngine;
using Zenject;

public interface ITextAreaView
{
    // 各RectTransformのサイズと位置を設定するメソッド
    void SetContentSize(Vector2 size);
    void SetAreaVoidstartLayout(Vector2 size, Vector2 position);
    void SetAreaVoidupdateLayout(Vector2 size, Vector2 position);
    void SetBlockVoidupdatePosition(Vector2 position);

    float SetContentWidth();
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
        view.SetContentSize(new Vector2(view.SetContentWidth(), layoutData.ContentHeight));

        view.SetAreaVoidstartLayout(layoutData.AreaVoidstartSize, layoutData.AreaVoidstartPosition);

        view.SetAreaVoidupdateLayout(layoutData.AreaVoidupdateSize, layoutData.AreaVoidupdatePosition);

        view.SetBlockVoidupdatePosition(layoutData.BlockVoidupdatePosition);
    }
}