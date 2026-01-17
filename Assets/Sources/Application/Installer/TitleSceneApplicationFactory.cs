using UnityEngine;

namespace UnityLike.Application
{
    public class TitleSceneApplicationFactory : ITitleSceneApplicationFactory
    {
        [SerializeField] private IUnityIconEntity unityIconEntity;

        public IUnityIconEntity GetUnityIconEntity()
        {
            return unityIconEntity;
        }
    }
}
