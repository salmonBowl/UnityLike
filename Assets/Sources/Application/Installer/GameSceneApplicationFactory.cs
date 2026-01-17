using UnityEngine;

namespace UnityLike.Application
{
    public class GameSceneApplicationFactory : MonoBehaviour, IGameSceneApplicationFactory
    {
        [SerializeField]
        private GameObject prefab01;

        public void CreateEntity01()
        {

        }
    }
}
