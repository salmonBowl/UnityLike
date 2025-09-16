using UnityEngine;
using UnityEngine.UI;

namespace UnityLike.FrameworkAndDrivers.TitleScene
{
    public class TitleSceneController : MonoBehaviour
    {
        [SerializeField] UIAnimator animator;
        [SerializeField] SceneTransitionManager sceneTransition;

        void Start()
        {
            Application.targetFrameRate = 60;
        }
        public void ButtonCreateNewProjectPointerEnter()
        {
            if (!sceneTransition.WhileFadeOut())
                animator.SetRotationDestination(-120);
        }
        public void ButtonLoadProjectPointerEnter()
        {
            if (!sceneTransition.WhileFadeOut())
                animator.SetRotationDestination(120);
        }
        public void ButtonPointerExit()
        {
            if (!sceneTransition.WhileFadeOut())
                animator.SetRotationDestination(0);
        }

        public void CreateNewProject()
        {
            sceneTransition.StartFadeOut();
        }
        public void LoadProject()
        {
            sceneTransition.StartFadeOut();
        }
    }
}
