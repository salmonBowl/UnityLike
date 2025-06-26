using static UnityEngine.Vector2;
using static UnityEngine.Mathf;
using Zenject;

public interface ITextAreaLayoutPresenter
{
    void PresenterLayout(TextAreaLayoutData layoutData);

}

public class UpdateTextAreaUseCase
{

    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly CodeEditorSettings settings;
    private readonly ITextAreaLayoutPresenter layoutPresenter;

    [Inject]
    public UpdateTextAreaUseCase(
        CodeEditorLineCountManager lineCountManager,
        CodeEditorSettings settings,
        ITextAreaLayoutPresenter layoutPresenter
        )
    {
        this.lineCountManager = lineCountManager;
        this.settings = settings;
        this.layoutPresenter = layoutPresenter;
    }

    public void Execute()
    {
        if (settings == null)
        {
            UnityEngine.Debug.LogError("UpdateTextAreaUseCase : settingsが設定されていません");
        }

        // InputFieldのサイズを計算

        float heightVoidstart = Mathf.Max(
            settings.lowerHeightInputField,
            settings.lineHeight * lineCountManager.LineCountVoidstart
            );
        float heightVoidupdate = Mathf.Max(
            settings.lowerHeightInputField,
            settings.lineHeight * lineCountManager.LineCountVoidupdate
            );

        // レイアウトデータを生成
        float contentHeight = heightVoidstart + heightVoidupdate + 4.3f;
        UnityEngine.Vector2 areaVoidstartSize = new(11f, heightVoidstart);
        UnityEngine.Vector2 areaVoidupdateSize = new(11f, heightVoidupdate);
        UnityEngine.Vector2 areaVoidstartPosition = new(0, heightVoidstart * -0.5f + 0.5f);
        UnityEngine.Vector2 areaVoidupdatePosition = new(0, heightVoidupdate * -0.5f + 0.5f);
        UnityEngine.Vector2 blockVoidupdatePosition = new(0, -heightVoidstart - 4.0f);

        TextAreaLayoutData layoutData = new(
            contentHeight,
            heightVoidstart,
            heightVoidupdate,
            areaVoidstartSize,
            areaVoidupdateSize,
            areaVoidstartPosition,
            areaVoidupdatePosition,
            blockVoidupdatePosition
        );

        // レイアウトデータの出力
        layoutPresenter.PresenterLayout(layoutData);
    }
}
