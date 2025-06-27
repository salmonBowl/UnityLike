using System;
using UnityEngine;

public class CodeEditorTextAreaUI : MonoBehaviour, ITextAreaView, ITextAreaInput
{
    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private RectTransform areaVoidstart;
    [SerializeField]
    private RectTransform areaVoidupdate;

    [SerializeField]
    private RectTransform blockVoidupdate;

    public event Action<CodeEditorBlock, string> OnTextAreaInputChanged;

    public float GetContentWidth()
    {
        if (content == null)
        {
            Debug.LogError("content���w�肳��Ă��܂���");
            return 0f;
        }

        return content.rect.width;
    }

    /*
        View
     */

    public void SetContentSize(Vector2 anchoredSize)
    {
        if (content == null)
        {
            Debug.LogError("content���w�肳��Ă��܂���");
            return;
        }

        content.sizeDelta = anchoredSize;
    }
    public void SetAreaVoidstartLayout(Vector2 size, Vector2 anchoredPosition)
    {
        if (areaVoidstart == null)
        {
            Debug.LogError("areaVoidstart���w�肳��Ă��܂���");
            return;
        }

        areaVoidstart.sizeDelta = size;
        areaVoidstart.anchoredPosition = anchoredPosition;
    }
    public void SetAreaVoidupdateLayout(Vector2 size, Vector2 anchoredPosition)
    {
        //Debug.Log("SetAreaViudupdateLayout()");

        if (areaVoidupdate == null)
        {
            Debug.LogError("areaVoidupdate���w�肳��Ă��܂���");
            return;
        }

        areaVoidupdate.sizeDelta = size;
        areaVoidupdate.anchoredPosition = anchoredPosition;
    }
    public void SetBlockVoidupdatePosition(Vector2 anchoredPosition)
    {
        if (blockVoidupdate == null)
        {
            Debug.LogError("blockVoidupdate���w�肳��Ă��܂���");
            return;
        }

        blockVoidupdate.anchoredPosition = anchoredPosition;
    }

    /*
        Input
     */
    public void OnAreaVoidstartTextChanged(string newText)
    {
        //Debug.Log("CodeEditorTextAreaUI : OnAreaVoidstartTextChanged");
        //Debug.Log("CodeEditorTextAreaUI.OnAreaVoidstartTextChanged : newText = " + newText);

        OnTextAreaInputChanged?.Invoke(CodeEditorBlock.VoidStart, newText);
    }
    public void OnAreaVoidupdateTextChanged(string newText)
    {
        OnTextAreaInputChanged?.Invoke(CodeEditorBlock.VoidUpdate, newText);
    }
}
