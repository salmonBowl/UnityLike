using UnityEngine;
using UnityLike.Domain.IPresenter;
using UnityLike.Domain.UseCase;
using Zenject;

namespace UnityLike.Main
{
    public class TitleSceneMain : MonoBehaviour
    {
        private readonly TitleScene titleScene;

        [Inject]
        public TitleSceneMain(ITitleScenePresenter icon)
        {
            titleScene = new(icon);
        }

        void Awake()
        {
            
        }
        void Update()
        {

        }
        void OnDestroy()
        {

        }
    }
}
