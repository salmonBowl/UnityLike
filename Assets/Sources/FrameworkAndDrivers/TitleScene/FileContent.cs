using UnityEngine;
using TMPro;

namespace UnityLike.FrameworkAndDrivers.TitleScene
{
    public class FileContent : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text text;

        public void SetText(string newText)
        {
            text.text = newText;
        }

        public void Instantiate(Transform parent, string newText)
        {
            FileContent newContent = Instantiate(gameObject, parent).GetComponent<FileContent>();
            newContent.SetText(newText);
        }
    }
}
