using Zenject;

public enum CodeEditorBlock
{
    VoidStart,
    VoidUpdate,
    MaxNum
}

public class CodeEditor
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly CodeEditorTextAreaSize textAreaSize;

    private readonly CodeEditorSettings settings;


    [Inject]
    public CodeEditor(
        CodeEditorLineCountManager lineCountManager,
        CodeEditorTextAreaSize textAreaSize,
        CodeEditorSettings settings
    )
    {
        this.lineCountManager = lineCountManager;
        this.textAreaSize = textAreaSize;
        this.settings = settings;
    }

    public void Update()
    {
        // lineCount��UI����̃C�x���g�쓮�Ȃ̂�Update������Ȃ�
        //lineCountManager.Update();

        textAreaSize.DebugGenerateClass();
        textAreaSize.Update();
    }
}