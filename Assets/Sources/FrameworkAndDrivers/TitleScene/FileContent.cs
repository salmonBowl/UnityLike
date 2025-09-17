using UnityEngine;
using TMPro;
using UnityLike.FrameworkAndDrivers.SceneLoad;

namespace UnityLike.FrameworkAndDrivers.TitleScene
{
    public class FileContent : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text textComponent;

        private SceneTransitionManager sceneTransition;

        public void SetText(string newText)
        {
            textComponent.text = newText;
        }

        public void OnButtonDown()
        {
            FilePath.SetPath("SaveData/" + textComponent.text + ".json");
            sceneTransition.StartFadeOut();
        }

        public void Instantiate(Transform parent, string newText, SceneTransitionManager sceneTransition)
        {
            FileContent newContent = Instantiate(gameObject, parent).GetComponent<FileContent>();
            newContent.SetText(newText);

            newContent.sceneTransition = sceneTransition;
        }
    }
}
