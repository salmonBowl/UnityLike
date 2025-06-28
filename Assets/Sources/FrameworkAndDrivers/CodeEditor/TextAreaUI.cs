using System;
using UnityEngine;
using TMPro;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.Controller;
using UnityLike.InterfaceAdapters.Presenter;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class TextAreaUI : MonoBehaviour, ITextAreaView, ITextAreaInput, IGetInputFieldText
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
        private TMP_InputField inputFieldVoidstart;
        [SerializeField]
        private TMP_InputField inputFieldVoidupdate;

        public event Action<CodeEditorBlock, string> OnTextAreaInputChanged;

        /*
            Get
         */
        public float GetContentWidth()
        {
            if (content == null)
            {
                Debug.LogError("content���w�肳��Ă��܂���");
                return 0f;
            }

            return content.rect.width;
        }
        public string GetInputFieldText(CodeEditorBlock block)
        {
            switch (block)
            {
                case CodeEditorBlock.VoidStart:

                    if (!inputFieldVoidstart)
                    {
                        Debug.LogError("inputFieldVoidstart���A�^�b�`����Ă��܂���");
                        return "";
                    }
                    return inputFieldVoidstart.text;
                case CodeEditorBlock.VoidUpdate:

                    if (!inputFieldVoidupdate)
                    {
                        Debug.LogError("inputFieldVoidupdate���A�^�b�`����Ă��܂���");
                        return "";
                    }
                    return inputFieldVoidupdate.text;

                default:
                    Debug.LogError("CodeEditorTextAreaUI.GetInputFieldText : �L�q����Ă��Ȃ�Enum�l�ł�");
                    return "";
            }
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
            switch (block)
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
                default:
                    Debug.LogError("CodeEditorTextAreaUI.SetTextInputField : �L�q����Ă��Ȃ�Enum�l�ł�");
                    return;
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
}
