using UnityEngine;
using Zenject;

using UnityLike.FrameworkAndDrivers.GameObjectManagement;
using UnityLike.FrameworkAndDrivers.SceneLoad;

namespace UnityLike.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        [Header("MonoBehaviourの依存関係解決のために必要なインスタンスを取得します")]
        [SerializeField]
        private GameObjectFactory gameObjectFactoryInstance;

        public override void InstallBindings()
        {
            Container.Bind<GameObjectManager>().AsSingle();
            Container.Bind<GameObjectFactory>().FromInstance(gameObjectFactoryInstance);
            Container.Bind<SceneLoader>().AsSingle();
        }
    }
}
