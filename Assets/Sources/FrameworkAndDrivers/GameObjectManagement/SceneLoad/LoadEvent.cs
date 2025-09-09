
using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.GameObjectManagement
{
    public class LoadEvent : MonoBehaviour
    {
        [SerializeField]
        private GameObjectManager gameObjectManager;

        private SceneLoader sceneLoader;

        void Start()
        {
            sceneLoader = new(gameObjectManager);

            sceneLoader.LoadScene();
        }
        private void OnApplicationQuit()
        {
            sceneLoader.SaveScene();
        }
    }
}
