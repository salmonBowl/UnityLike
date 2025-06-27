using System;
using UnityEngine;
using UnityEngine.UI;

public class CodeEditorTextAreaUI : MonoBehaviour, ITextAreaView, ITextAreaInput
{
    [Header("�z�u�֌W")]
    [SerializeField]
    private RectTransform content;

    [SerializeField]
    private RectTransform areaVoidstart;
    [SerializeField]
    private RectTransform areaVoidupdate;

    [SerializeField]
    private RectTransform blockVoidupdate;

    [Header("InputField�֌W")]
    [SerializeField]
    private InputField inputFieldVoidstart;
    [SerializeField]
    private InputField inputFieldVoidupdate;

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
            Debug.LogError("content���A�^�b�`����Ă��܂���");
            return;
        }

        content.sizeDelta = anchoredSize;
    }
    public void SetAreaVoidstartLayout(Vector2 size, Vector2 anchoredPosition)
    {
        if (areaVoidstart == null)
        {
            Debug.LogError("areaVoidstart���A�^�b�`����Ă��܂���");
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
            Debug.LogError("areaVoidupdate���A�^�b�`����Ă��܂���");
            return;
        }

        areaVoidupdate.sizeDelta = size;
        areaVoidupdate.anchoredPosition = anchoredPosition;
    }
    public void SetBlockVoidupdatePosition(Vector2 anchoredPosition)
    {
        if (blockVoidupdate == null)
        {
            Debug.LogError("blockVoidupdate���A�^�b�`����Ă��܂���");
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
                    Debug.LogError("inputFieldVoidstart���A�^�b�`����Ă��܂���");
                    return;
                }
                inputFieldVoidstart.text = text;

                break;
            case CodeEditorBlock.VoidUpdate:

                if (!inputFieldVoidupdate)
                {
                    Debug.LogError("inputFieldVoidupdate���A�^�b�`����Ă��܂���");
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
