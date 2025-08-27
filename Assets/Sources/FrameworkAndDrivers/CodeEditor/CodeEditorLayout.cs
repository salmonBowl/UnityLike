using UnityEngine;

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

        public float GetContentWidth()
        {
            if (content == null)
            {
                Debug.LogError("contentが指定されていません");
                return 0f;
            }

            return content.rect.width;
        }

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
    }
}
