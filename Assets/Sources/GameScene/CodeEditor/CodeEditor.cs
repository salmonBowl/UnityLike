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
        // lineCount‚ÍUI‚©‚ç‚ÌƒCƒxƒ“ƒg‹ì“®‚È‚Ì‚ÅUpdate‚ª‚¢‚ç‚È‚¢
        //lineCountManager.Update();

        textAreaSize.Update();
    }
}