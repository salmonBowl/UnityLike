using UnityEngine;

namespace UnityLike.Application
{
    public class UnityIconBehaviour : MonoBehaviour
    {
        private class UnityIconEntity : IUnityIconEntity
        {
            private readonly ViewableUnityIcon viewData;

            public UnityIconEntity(UnityIcon unityIcon)
            {
                viewData = new ViewableUnityIcon(unityIcon);
            }

            public override void ViewUpdate()
            {

            }
        }
    }
}
