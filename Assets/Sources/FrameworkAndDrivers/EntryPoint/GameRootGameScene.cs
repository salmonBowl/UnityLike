using Zenject;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    public class GameRootGameScene
    {
        // CodeEditor
        private readonly CodeEditor codeEditor;



        //private readonly RectTransform    ;

        [Inject]
        public GameRootGameScene(CodeEditor codeEditor)
        {
            this.codeEditor = codeEditor;
        }

        public void Start()
        {

        }

        public void Update()
        {
            codeEditor.Update();


        }
    }
}
