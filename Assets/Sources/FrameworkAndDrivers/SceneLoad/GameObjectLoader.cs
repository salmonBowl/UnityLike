using UnityEngine;

using UnityLike.FrameworkAndDrivers.GameObjectManagement;

namespace UnityLike.FrameworkAndDrivers.SceneLoad
{
    // ロード機能ができるまでの仮システムとしてMonoBehaviourを使っています
    public class GameObjectLoader : MonoBehaviour
    {
        [SerializeField] private GameObjectManager gameObjectManager;

        [SerializeField] private GameObject cube;

        void Start()
        {
            gameObjectManager.AddGameObject(cube);
        }
    }
}
