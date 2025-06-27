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
        UpdateTextAreaUseCase updateTextAreaUseCase,
        ITextAreaInput textAreaInput
        )
    {
        UnityEngine.Debug.Log("CodeEditorInputController.Constructor()");

        this.lineCountManager = lineCountManager;
        this.updateTextAreaUseCase = updateTextAreaUseCase;
        this.textAreaInput = textAreaInput;
    }

    public void Initialize()
    {
        UnityEngine.Debug.Log("CodeEditorInputController.Initialize()");

        if (lineCountManager == null)
            UnityEngine.Debug.LogError("CodeEditorInputController : lineCountManager���ݒ肳��Ă��܂���");
        if (updateTextAreaUseCase == null)
            UnityEngine.Debug.LogError("CodeEditorInputController : updateTextAreaUseCase���ݒ肳��Ă��܂���");
        if (textAreaInput == null)
            UnityEngine.Debug.LogError("CodeEditorInputController : textAreaInput���ݒ肳��Ă��܂���");

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
        UnityEngine.Debug.Log("CodeEditorInputController | newText : " + newText);

        int newLineCount = CalculateLineCount(newText);

        UnityEngine.Debug.Log($"CodeEditorInputController | block : {block}, LineCount : {newLineCount}");

        lineCountManager.SetLineCount(block, newLineCount);
    }

    private int CalculateLineCount(string text)
    {
        if (string.IsNullOrEmpty(text))
            return 1;

        return text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Length;
    }
}