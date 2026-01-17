using UnityEngine;

namespace UnityLike.FrameworkAndDrivers.TitleScene
{
    public class TitleSceneController : MonoBehaviour
    {
        [SerializeField] GameObject newProject;
        [SerializeField] GameObject loadProject;

        [SerializeField] UIAnimator animator;

        void Start()
        {
            Application.targetFrameRate = 60;
        }
        public void ButtonCreateNewProjectPointerEnter()
        {
            animator.SetRotationDestination(-120);
        }
        public void ButtonLoadProjectPointerEnter()
        {
            animator.SetRotationDestination(120);
        }
        public void ButtonPointerExit()
        {
            animator.SetRotationDestination(0);
        }

        public void CreateNewProject()
        {
            newProject.SetActive(true);
            loadProject.SetActive(false);
        }
        public void LoadProject()
        {
            newProject.SetActive(false);
            loadProject.SetActive(true);
        }
    }
}
