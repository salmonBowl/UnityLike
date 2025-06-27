using System;
using UnityEngine;
using UnityEngine.UI;

public class CodeEditorTextAreaUI : MonoBehaviour, ITextAreaView, ITextAreaInput
{
    [Header("配置関係")]
    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private RectTransform areaVoidstart;
    [SerializeField]
    private RectTransform areaVoidupdate;

    [SerializeField]
    private RectTransform blockVoidupdate;

    [Header("InputField関係")]
    [SerializeField]
    private InputField inputFieldVoidstart;
    [SerializeField]
    private InputField inputFieldVoidupdate;

    public event Action<CodeEditorBlock, string> OnTextAreaInputChanged;

    public float GetContentWidth()
    {
        if (content == null)
        {
            Debug.LogError("contentが指定されていません");
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
            Debug.LogError("contentがアタッチされていません");
            return;
        }

        content.sizeDelta = anchoredSize;
    }
    public void SetAreaVoidstartLayout(Vector2 size, Vector2 anchoredPosition)
    {
        if (areaVoidstart == null)
        {
            Debug.LogError("areaVoidstartがアタッチされていません");
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
            Debug.LogError("areaVoidupdateがアタッチされていません");
            return;
        }

        areaVoidupdate.sizeDelta = size;
        areaVoidupdate.anchoredPosition = anchoredPosition;
    }
    public void SetBlockVoidupdatePosition(Vector2 anchoredPosition)
    {
        if (blockVoidupdate == null)
        {
            Debug.LogError("blockVoidupdateがアタッチされていません");
            return;
        }

        blockVoidupdate.anchoredPosition = anchoredPosition;
    }

    public void SetTextInputField(CodeEditorBlock block, string text)
    {
        switch(block)
        {
            case CodeEditorBlock.VoidStart:

                if (!inputFieldVoidstart)
                {
                    Debug.LogError("inputFieldVoidstartがアタッチされていません");
                    return;
                }
                inputFieldVoidstart.text = text;

                break;
            case CodeEditorBlock.VoidUpdate:

                if (!inputFieldVoidupdate)
                {
                    Debug.LogError("inputFieldVoidupdateがアタッチされていません");
                    return;
                }
                inputFieldVoidstart.text = text;

                break;
        }
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
