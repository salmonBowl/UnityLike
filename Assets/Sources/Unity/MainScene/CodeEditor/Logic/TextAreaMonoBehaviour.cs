using UnityEngine;
using TMPro;

namespace UnityLike.Unity.CodeEditor
{
    public class TextAreaMonoBehaviour : MonoBehaviour
    {
        [Header("��̃u���b�N�ɃA�^�b�`���܂�")]

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
                Debug.LogError("areaVoidupdate���A�^�b�`����Ă��܂���");
                return;
            }

            textArea.sizeDelta = new Vector2(textArea.sizeDelta.x, height);
            //textArea.anchoredPosition = new Vector2(textArea.anchoredPosition.x, height);
        }
        public void SetBlockPosY(float posY)
        {
            if (!textBlock)
            {
                Debug.LogError("blockVoidupdate���A�^�b�`����Ă��܂���");
                return;
            }

            textBlock.anchoredPosition = new Vector2(textBlock.anchoredPosition.x, posY);
        }
        public void RewriteInputText(string text)
        {
            if (!inputField)
            {
                Debug.LogError("inputField���A�^�b�`����Ă��܂���");
                return;
            }
            inputField.SetTextWithoutNotify(text);
        }
        public void SetViewText(string text)
        {
            if (!viewText)
            {
                Debug.LogError("viewText���A�^�b�`����Ă��܂���");
            }
            viewText.text = text;
        }
    }
}
