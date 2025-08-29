using UnityEngine;
using TMPro;

using UnityLike.InterfaceAdapters.CodeEditorMouseOver;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class ErrorPopupUI : MonoBehaviour, IPopupView
    {
        [SerializeField]
        private RectTransform popup;

        [SerializeField]
        private TextMeshProUGUI text;

        [SerializeField]
        private Canvas canvas;
        [SerializeField]
        private RectTransform parentTransform;

        void Start()
        {
            if (!popup)
                Debug.LogError("popupがアタッチされていません");
            if (!text)
                Debug.LogError("textがアタッチされていません");
            if (!canvas)
                Debug.LogError("textがアタッチされていません");
            if (!parentTransform)
                Debug.LogError("parentTransformがアタッチされていません");
        }

        public void ShowPopup()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                parentTransform, Input.mousePosition, canvas.worldCamera,
                out var mousePosition);
            Vector2 offset = new(0.5f, 0.5f);
            popup.localPosition = mousePosition + offset;

            popup.gameObject.SetActive(true);
        }
        public void HidePopup()
        {
            popup.gameObject.SetActive(false);
        }
        public void SetText(string message)
        {
            text.text = message;
        }
    }
}