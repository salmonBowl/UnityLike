using UnityEngine;

public class CodeEditorTextAreaSize
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly CodeEditorSettings settings;

    private readonly RectTransform areaVoidStart;
    private readonly RectTransform areaVoidUpdate;

    public CodeEditorTextAreaSize(
        CodeEditorLineCountManager lineCountManager,
        CodeEditorSettings settings,
        RectTransform areaVoidStart,
        RectTransform areaVoidUpdate
        )
    {
        this.lineCountManager = lineCountManager;
        this.settings = settings;

        this.areaVoidStart = areaVoidStart;
        this.areaVoidUpdate = areaVoidUpdate;
    }

    public void Execute()
    {

    }
    public void Render()
    {

    }
}
