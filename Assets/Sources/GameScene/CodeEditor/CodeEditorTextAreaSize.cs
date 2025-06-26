using UnityEngine;
using Zenject;

public class CodeEditorTextAreaSize
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly CodeEditorSettings settings;


    [Inject(Id = "content")]
    private readonly RectTransform content;

    [Inject(Id = "areaVoidstart")]
    private readonly RectTransform areaVoidstart;

    [Inject(Id = "blockVoidupdate")]
    private readonly RectTransform blockVoidupdate;
    [Inject(Id = "areaVoidupdate")]
    private readonly RectTransform areaVoidupdate;

    [Inject]
    public CodeEditorTextAreaSize(CodeEditorLineCountManager lineCountManager, CodeEditorSettings settings)
    {
        this.lineCountManager = lineCountManager;
        this.settings = settings;
    }

    public void Update()
    {
        //Debug.Log("textAreaSize.Update()");

        if (settings == null)
        {
            Debug.LogError("codeEditorSettingが指定されていません");
            return;
        }
        if (content == null)
        {
            Debug.LogError("contentが指定されていません");
            return;
        }
        if (areaVoidstart == null)
        {
            Debug.LogError("areaVoidstartが指定されていません");
            return;
        }
        if (blockVoidupdate == null)
        {
            Debug.LogError("blockVoidupdateが指定されていません");
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
        float heightVoidupdate = Mathf.Max(
            settings.lowerHeightInputField,
            settings.lineHeight * lineCountManager.LineCountVoidupdate
            );
        // 反映
        areaVoidstart.sizeDelta = new Vector2(11f, heightVoidstart);
        areaVoidstart.anchoredPosition = new Vector2(0, heightVoidstart * -0.5f + 0.5f);
        areaVoidupdate.sizeDelta = new Vector2(11f, heightVoidupdate);
        areaVoidupdate.anchoredPosition = new Vector2(0, heightVoidupdate * -0.5f + 0.5f);

        // voidupdateの位置補正
        blockVoidupdate.anchoredPosition = new Vector2(0, -heightVoidstart - 4.0f);

        // contentサイズ(スクロール範囲)の補正
        float contentHeight = heightVoidstart + heightVoidupdate + 4.3f;
        content.sizeDelta = new Vector2(content.sizeDelta.x, contentHeight);
    }
}
