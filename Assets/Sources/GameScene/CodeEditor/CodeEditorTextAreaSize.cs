using UnityEngine;

public class CodeEditorTextAreaSize
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly CodeEditorSettings settings;

    private readonly RectTransform areaVoidstart;
    private readonly RectTransform areaVoidupdate;

    public CodeEditorTextAreaSize(
        CodeEditorLineCountManager lineCountManager,
        CodeEditorSettings settings,
        RectTransform areaVoidstart,
        RectTransform areaVoidupdate
        )
    {
        this.lineCountManager = lineCountManager;
        this.settings = settings;

        this.areaVoidstart = areaVoidstart;
        this.areaVoidupdate = areaVoidupdate;
    }

    public void Update()
    {
        //Debug.Log("textAreaSize.Update()");
        if (settings == null)
        {
            Debug.LogError("codeEditorSettingが指定されていません");
            return;
        }
        if (areaVoidstart == null)
        {
            Debug.LogError("areaVoidstartが指定されていません");
            return;
        }
        if (areaVoidupdate == null)
        {
            Debug.LogError("areaVoidupdateが指定されていません");
            return;
        }

        //areaVoidstart.anchoredPosition = new Vector2(0, 1f);
        //areaVoidupdate.anchoredPosition = new Vector2(0, heightVoidstart - 0.2f);

        // InputFieldのサイズを調整
        // サイズを計算して
        float heightVoidstart = Mathf.Max(
            settings.lowerHeightInputField,
            settings.lineHeight * lineCountManager.LineCountVoidstart
            );
        // 反映
        areaVoidstart.sizeDelta = new Vector2(11f, heightVoidstart);
        areaVoidstart.anchoredPosition = new Vector2(0, heightVoidstart * -0.5f + 0.5f);

        //
    }
}
