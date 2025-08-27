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

        public void ShowPopup()
        {
            Vector3 offset = new Vector2(0.5f, 0.5f);
            popup.position = Input.mousePosition + offset;

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