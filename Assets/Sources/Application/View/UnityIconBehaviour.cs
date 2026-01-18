using UnityEngine;

namespace UnityLike.Application
{
    public class UnityIconBehaviour : MonoBehaviour
    {
        private UnityIconEntityImpl inner;

        public IUnityIconEntity Initialize(UnityIcon unityIcon)
        {
            inner = new UnityIconEntityImpl(gameObject, unityIcon);

            return inner;
        }

        void OnDestroy()
        {
            inner = null;
        }

        private class UnityIconEntityImpl : IUnityIconEntity
        {
            private readonly GameObject gameObject;

            private readonly ViewableUnityIcon viewData;

            public UnityIconEntityImpl(GameObject gameObject, UnityIcon unityIcon)
            {
                this.gameObject = gameObject;
                viewData = new ViewableUnityIcon(unityIcon);
            }

            public override void DrawUpdate()
            {
                float angleZ = viewData.GetAngle().Get();

                gameObject.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, angleZ);
            }
        }
    }
}
