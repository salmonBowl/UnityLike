using UnityEngine.SceneManagement;

namespace UnityLike.Presentation
{
    public class SceneTransitionRequest
    {
        private readonly SceneType nextSceneType;
        public SceneTransitionRequest(SceneType nextSceneType)
        {
            this.nextSceneType = nextSceneType;
        }

        public void Execute()
        {
            switch (nextSceneType)
            {
                case SceneType.Title:
                    SceneManager.LoadScene("TitleScene");
                    break;
                case SceneType.Game:
                    SceneManager.LoadScene("GameScene");
                    break;
            }
        }
    }
}
