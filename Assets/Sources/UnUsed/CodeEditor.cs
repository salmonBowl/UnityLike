using Zenject;

public class CodeEditor
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly UpdateTextAreaUseCase updateTextAreaUseCase;

    private readonly CodeEditorSettings settings;


    [Inject]
    public CodeEditor(
        CodeEditorLineCountManager lineCountManager,
        UpdateTextAreaUseCase updateTextAreaUseCase,
        CodeEditorSettings settings
    )
    {
        this.lineCountManager = lineCountManager;
        this.updateTextAreaUseCase = updateTextAreaUseCase;
        this.settings = settings;
    }

    public void Update()
    {
        // lineCount‚ÍUI‚©‚ç‚ÌƒCƒxƒ“ƒg‹ì“®‚È‚Ì‚ÅUpdate‚ª‚¢‚ç‚È‚¢
        //lineCountManager.Update();

        //updateTextAreaUseCase.Execute();
    }
}