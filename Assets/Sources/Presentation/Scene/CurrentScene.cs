namespace UnityLike.Presentation
{
    public class CurrentScene
    {
        private Scene currentScene;

        public void Is(Scene currentScene)
        {
            if (this.currentScene == null)
                this.currentScene = currentScene;
            else
                throw new ValueAlreadySetException("currentSceneは既に指定されています");
        }

        public void SetUp()
        {
            if (currentScene == null)
                throw new NullReferanceException("sceneが指定されていません");

            currentScene.SetUp();
        }
        public void Update(out SceneType nextScene)
        {
            TimeSpan deltaTime = new(UnityEngine.Time.deltaTime, TimeUnit.sec);

            nextScene = currentScene.Update(deltaTime);
        }
        public bool ShouldTransitionTo(SceneType nextScene)
        {
            return currentScene.GetSceneType() != nextScene;
        }
        public void Transition(SceneType nextScene)
        {
            // シーン遷移のリクエストを作成します
            var transition = new SceneTransitionRequest(nextScene);

            transition.Execute();
        }
    }
}
