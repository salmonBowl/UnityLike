using System;
using UnityEngine;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.TextAreaLayout;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class CodeEditorLayout : MonoBehaviour, ITextAreaView
    {
        [SerializeField]
        private RectTransform content;

        [SerializeField]
        private RectTransform areaVoidstart;
        [SerializeField]
        private RectTransform areaVoidupdate;

        [SerializeField]
        private RectTransform blockVoidupdate;

        [SerializeField]
        private InputFieldUI InputFieldVoidstart;
        [SerializeField]
        private InputFieldUI InputFieldVoidupdate;

        void Start() => AttachmentInspection();
        private void AttachmentInspection()
        {
            if (!content)
                Debug.LogError("contentがアタッチされていません");
            if (!areaVoidstart)
                Debug.LogError("areaVoidstartがアタッチされていません");
            if (!areaVoidupdate)
                Debug.LogError("areaVoidupdateがアタッチされていません");
            if (!blockVoidupdate)
                Debug.LogError("blockVoidupdateがアタッチされていません");
            InputFieldVoidstart.AttachmentInspection();
            InputFieldVoidupdate.AttachmentInspection();
        }

        public float GetContentWidth()
        {
            return content.rect.width;
        }

        public void SetContentSize(Vector2 anchoredSize)
        {
            content.sizeDelta = anchoredSize;
        }
        public void SetAreaVoidstartLayout(Vector2 size, Vector2 anchoredPosition)
        {
            areaVoidstart.sizeDelta = size;
            areaVoidstart.anchoredPosition = anchoredPosition;
        }
        public void SetAreaVoidupdateLayout(Vector2 size, Vector2 anchoredPosition)
        {
            areaVoidupdate.sizeDelta = size;
            areaVoidupdate.anchoredPosition = anchoredPosition;
        }
        public void SetBlockVoidupdatePosition(Vector2 anchoredPosition)
        {
            blockVoidupdate.anchoredPosition = anchoredPosition;
        }
    }
}
