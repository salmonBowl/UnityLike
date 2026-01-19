using UnityEngine;
using UnityEngine.UI;

using UnityLike.UI;

namespace UnityLike.Application
{
    public class CreateWindowBehaviour : MonoBehaviour
    {
        private CreateWindowEntityImpl inner;

        [SerializeField] Button createWindowOpen;
        [SerializeField] GameObject createWindow;

        public ICreateWindowEntity Initialize(CreateWindow createWindow)
        {
            inner = new CreateWindowEntityImpl(this, createWindow);

            return inner;
        }

        void OnDestroy()
        {
            inner = null;
        }

        private class CreateWindowEntityImpl : ICreateWindowEntity
        {
            private readonly CreateWindowBehaviour outher;
            private readonly ViewableCreateWindow viewData;

            public CreateWindowEntityImpl(CreateWindowBehaviour outher, CreateWindow createWindow)
            {
                this.outher = outher;
                viewData = new ViewableCreateWindow(createWindow);
            }

            public override void DrawUpdate()
            {

            }
        }
    }
}
