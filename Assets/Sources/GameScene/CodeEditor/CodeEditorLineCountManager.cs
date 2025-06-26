using System;

public class CodeEditorLineCountManager
{
    public int LineCountVoidstart { get; private set; }
    public int LineCountVoidupdate { get; private set; }

    public event Action<CodeEditorBlock> OnLineCountChanged;

    public CodeEditorLineCountManager()
    {
        LineCountVoidstart = 1;
        LineCountVoidupdate = 1;
    }

    public void SetLineCount(CodeEditorBlock block, int value)
    {
        switch (block)
        {
            case CodeEditorBlock.VoidStart:
                LineCountVoidstart = value;
                break;
            case CodeEditorBlock.VoidUpdate:
                LineCountVoidupdate = value;
                break;
            default:
                UnityEngine.Debug.LogError($"想定されていないブロックが指定されました : CodeEditorLineCountManager.SetLineCount({block}, {value})");
                break;
        }

        OnLineCountChanged?.Invoke(block);
    }
}