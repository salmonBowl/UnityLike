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
        private RectTransform canvasTransform;

        void Start()
        {
            if (!popup)
                Debug.LogError("popupがアタッチされていません");
            if (!text)
                Debug.LogError("textがアタッチされていません");
            if (!canvas)
                Debug.LogError("textがアタッチされていません");

            canvasTransform = canvas.GetComponent<RectTransform>();
        }

        public void ShowPopup()
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvasTransform, Input.mousePosition, canvas.worldCamera,
                out var mousePosition);
            Vector2 offset = new(0.5f, 0.5f);
            popup.position = mousePosition + offset;

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