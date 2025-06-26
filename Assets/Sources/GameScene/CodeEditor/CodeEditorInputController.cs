using System;
using Zenject;

public interface ITextAreaInput
{
    public event Action<CodeEditorBlock, string> OnTextAreaInputChanged;
}


public class CodeEditorInputController : IInitializable, IDisposable
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly UpdateTextAreaUseCase updateTextAreaUseCase;
    private readonly ITextAreaInput textAreaInput;

    [Inject]
    public CodeEditorInputController(
        CodeEditorLineCountManager lineCountManager,
        UpdateTextAreaUseCase updateTextAreaUseCase
        )
    {
        this.lineCountManager = lineCountManager;
        this.updateTextAreaUseCase = updateTextAreaUseCase;
    }

    public void Initialize()
    {
        // View��Controller��LineCount
        textAreaInput.OnTextAreaInputChanged += OnTextInputChanged;
        
        //LineCount��Controller��UseCase.Execute
        lineCountManager.OnLineCountChanged += OnLineCountChangedHandler;

        // �����\���̂��߂Ɉ�x�������s
        updateTextAreaUseCase.Execute();
    }
    public void Dispose()
    {
        textAreaInput.OnTextAreaInputChanged -= OnTextInputChanged;
        lineCountManager.OnLineCountChanged -= OnLineCountChangedHandler;
    }

    private void OnLineCountChangedHandler()
    {
        updateTextAreaUseCase.Execute();
    }
    private void OnTextInputChanged(CodeEditorBlock block, string newText)
    {
        int newLineCount = CalculateLineCount(newText);
        lineCountManager.SetLineCount(block, newLineCount);
    }

    private int CalculateLineCount(string text)
    {
        if (string.IsNullOrEmpty(text))
            return 1;

        return text.Split('\n').Length + 1;
    }
}