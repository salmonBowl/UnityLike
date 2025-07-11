using UnityEngine;
using TMPro;

namespace UnityLike.Unity.CodeEditor
{
    public class TextAreaMonoBehaviour : MonoBehaviour
    {
        [Header("一つのブロックにアタッチします")]

        [SerializeField]
        private RectTransform textBlock;

        [SerializeField]
        private RectTransform textArea;

        [SerializeField]
        private TMP_InputField inputField;

        [SerializeField]
        private TextMeshProUGUI viewText;

        private void Start()
        {
            inputField = GetComponent<TMP_InputField>();
            viewText = transform.Find("").GetComponent<TextMeshProUGUI>();
        }

        public void SetBlockHeight(float height)
        {
            if (!textArea)
            {
                Debug.LogError("areaVoidupdateがアタッチされていません");
                return;
            }

            textArea.sizeDelta = new Vector2(textArea.sizeDelta.x, height);
            //textArea.anchoredPosition = new Vector2(textArea.anchoredPosition.x, height);
        }
        public void SetBlockPosY(float posY)
        {
            if (!textBlock)
            {
                Debug.LogError("blockVoidupdateがアタッチされていません");
                return;
            }

            textBlock.anchoredPosition = new Vector2(textBlock.anchoredPosition.x, posY);
        }
        public void RewriteInputText(string text)
        {
            if (!inputField)
            {
                Debug.LogError("inputFieldがアタッチされていません");
                return;
            }
            inputField.SetTextWithoutNotify(text);
        }
        public void SetViewText(string text)
        {
            if (!viewText)
            {
                Debug.LogError("viewTextがアタッチされていません");
            }
            viewText.text = text;
        }
    }
}
