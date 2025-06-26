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
        float contentHeight = heightVoidstart + heightVoidupdate + 4.3f;
    }
}
