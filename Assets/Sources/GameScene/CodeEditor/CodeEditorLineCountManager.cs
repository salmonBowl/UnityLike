using UnityEngine;

public class CodeEditorLineCountManager
{
    public int LineCountVoidstart => lineCountVoidstart;
    public int LineCountVoidupdate => lineCountVoidupdate;

    private int lineCountVoidstart = 5;
    private int lineCountVoidupdate;

    public void SetLineCount(CodeEditorBlock block, int value)
    {
        switch (block)
        {
            case CodeEditorBlock.VoidStart:
                lineCountVoidstart = value;
                break;
            case CodeEditorBlock.VoidUpdate:
                lineCountVoidupdate = value;
                break;
            default:
                Debug.LogError($"�z�肳��Ă��Ȃ��u���b�N���w�肳��܂��� : CodeEditorLineCountManager.SetLineCount({block}, {value})");
                break;
        }
    }
}