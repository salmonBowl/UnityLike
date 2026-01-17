using UnityEngine;

namespace UnityLike.Application
{
    public abstract class Main : MonoBehaviour
    {
        protected readonly CurrentScene currentScene = new();

        protected abstract void Awake();

        private void Start()
        {
            currentScene.SetUp();

            UnityEngine.Application.targetFrameRate = 60;
        }

        private void Update()
        {
            currentScene.Update(out SceneType nextScene);

            if (currentScene.ShouldTransitionTo(nextScene))
            {
                currentScene.Transition(nextScene);
            }
        }
    }
}
