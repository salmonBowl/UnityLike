using UnityEngine;

public class CodeEditorLineCountManager
{
    public int LineCountVoidstart => lineCountVoidstart;
    public int LineCountVoidupdate => lineCountVoidupdate;

    readonly int lineCountLowerLimit = 3;

    private int lineCountVoidstart;
    private int lineCountVoidupdate;

    public void SetLineCount(CodeEditorBlock block, int value)
    {
        if (value < lineCountLowerLimit)
        {
            value = lineCountLowerLimit;
        }

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