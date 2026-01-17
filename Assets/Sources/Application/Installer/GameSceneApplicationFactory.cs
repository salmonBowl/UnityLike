using UnityEngine;

namespace UnityLike.Application
{
    public class GameSceneApplicationFactory : ApplicationFactoryBase, IGameSceneApplicationFactory
    {
        [SerializeField] GameObject prefab01;

        public void CreateEntity01()
        {

        }
    }
}
