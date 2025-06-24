using Unity.VisualScripting;
using UnityEngine;

public enum CodeEditorBlock
{
    VoidStart,
    VoidUpdate,
}

public class CodeEditor
{
    private readonly CodeEditorSettings settings;


    readonly CodeEditorLineCountManager lineCountManager;
    readonly CodeEditorTextAreaSize textAreaSize;

    public CodeEditor(
        CodeEditorSettings settings,
        RectTransform areaVoidstart,
        RectTransform areaVoidupdate
    )
    {
        lineCountManager = new();
        textAreaSize = new(lineCountManager, settings, areaVoidstart, areaVoidupdate);
    }

    public void Update()
    {
        // lineCount‚ÍUI‚©‚ç‚ÌƒCƒxƒ“ƒg‹ì“®‚È‚Ì‚ÅUpdate‚ª‚¢‚ç‚È‚¢
        //lineCountManager.Update();

        textAreaSize.Update();
    }
}