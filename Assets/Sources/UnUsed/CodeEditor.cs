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
        // lineCount��UI����̃C�x���g�쓮�Ȃ̂�Update������Ȃ�
        //lineCountManager.Update();

        //updateTextAreaUseCase.Execute();
    }
}