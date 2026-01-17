using UnityEngine;

namespace UnityLike.Presentation
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
