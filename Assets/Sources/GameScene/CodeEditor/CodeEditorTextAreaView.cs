using UnityEngine;
using Zenject;

public class CodeEditorTextAreaView : MonoBehaviour, ITextAreaView
{
    private readonly CodeEditorLineCountManager lineCountManager;
    private readonly CodeEditorSettings settings;

    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private RectTransform areaVoidstart;
    [SerializeField]
    private RectTransform areaVoidupdate;

    [SerializeField]
    private RectTransform blockVoidupdate;

    [Inject]
    public CodeEditorTextAreaView(CodeEditorLineCountManager lineCountManager, CodeEditorSettings settings)
    {
        this.lineCountManager = lineCountManager;
        this.settings = settings;
    }

    public float GetContentWidth() => content.rect.width;

    public void SetContentSize()
    {

    }

    public void Execute()
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
