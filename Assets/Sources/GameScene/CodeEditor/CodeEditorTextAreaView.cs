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

    public float GetContentWidth()
    {
        if (content == null)
        {
            Debug.LogError("contentが指定されていません");
            return 0f;
        }

        return content.rect.width;
    }

    public void SetContentSize(Vector2 size)
    {
        if (content == null)
        {
            Debug.LogError("contentが指定されていません");
            return;
        }

        areaVoidupdate.sizeDelta = size;
    }
    public void SetAreaVoidstartLayout(Vector2 size, Vector2 anchoredPosition)
    {
        if (areaVoidstart == null)
        {
            Debug.LogError("areaVoidstartが指定されていません");
            return;
        }

        areaVoidstart.sizeDelta = size;
        areaVoidstart.anchoredPosition = anchoredPosition;
    }
    public void SetAreaVoidupdateLayout(Vector2 size, Vector2 anchoredPosition)
    {
        if (areaVoidupdate == null)
        {
            Debug.LogError("areaVoidupdateが指定されていません");
            return;
        }

        areaVoidupdate.sizeDelta = size;
        areaVoidupdate.anchoredPosition = anchoredPosition;
    }
    public void SetBlockVoidupdatePosition(Vector2 anchoredPosition)
    {
        if (blockVoidupdate == null)
        {
            Debug.LogError("blockVoidupdateが指定されていません");
            return;
        }

        blockVoidupdate.anchoredPosition = anchoredPosition;
    }

    public void Execute()
    {
        Debug.Log("textAreaSize.Update()");

        if (settings == null)
        {
            Debug.LogError("codeEditorSettingが指定されていません");
            return;
        }
    }
}
