using Unity.VisualScripting;
using UnityEngine;

public enum CodeEditorBlock
{
    VoidStart,
    VoidUpdate,
    MaxNum
}

public class CodeEditor
{


    readonly CodeEditorLineCountManager lineCountManager;
    readonly CodeEditorTextAreaSize textAreaSize;

    public CodeEditor(
        CodeEditorSettings settings,
        RectTransform content,
        RectTransform areaVoidstart,
        RectTransform blockVoidupdate,
        RectTransform areaVoidupdate
    )
    {
        lineCountManager = new();
        textAreaSize = new(lineCountManager, settings, content, areaVoidstart, blockVoidupdate, areaVoidupdate);
    }

    public void Update()
    {
        // lineCount��UI����̃C�x���g�쓮�Ȃ̂�Update������Ȃ�
        //lineCountManager.Update();

        textAreaSize.Update();
    }
}