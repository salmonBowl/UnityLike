using UnityEngine;
using Zenject;

namespace UnityLike.FrameworkAndDrivers.SceneLoad
{
    public class LoadEvent : MonoBehaviour
    {
        [Inject]
        private readonly SceneLoader sceneLoader;

        void Start()
        {
            Application.targetFrameRate = 60;

            sceneLoader.LoadScene();
        }
        private void OnApplicationQuit()
        {
            sceneLoader.SaveScene();
        }
    }
}
