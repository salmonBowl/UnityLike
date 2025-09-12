using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.SceneLoad
{
    public class LoadEvent : MonoBehaviour
    {
        private readonly SceneLoader sceneLoader;

        void Start()
        {
            sceneLoader.LoadScene();
        }
        private void OnApplicationQuit()
        {
            sceneLoader.SaveScene();
        }
    }
}
