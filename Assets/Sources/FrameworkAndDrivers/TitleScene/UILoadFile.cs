using UnityEngine;
using UnityEngine.UI;
using UnityLike.FrameworkAndDrivers.IO;

namespace UnityLike.FrameworkAndDrivers.TitleScene
{
    public class UILoadFile : MonoBehaviour
    {
        [SerializeField]
        private FileContent fileContentPrefab;
        [SerializeField]
        private Transform fileContentParent;
        [SerializeField]
        private SceneTransitionManager sceneTransition;

        void OnEnable()
        {
            ShowAllFiles();
        }

        void ShowAllFiles()
        {
            DirectoryLoader loader = new();

            foreach (string fileName in loader.GetAllFileNames())
            {
                fileContentPrefab.Instantiate(fileContentParent, fileName, sceneTransition);
            }
        }
    }
}
