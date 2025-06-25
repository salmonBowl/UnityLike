
using UnityEngine;

public class GameRootGameScene
{
    // CodeEditor
    private readonly CodeEditor codeEditor;
    

    
    //private readonly RectTransform    ;

    public GameRootGameScene(
        CodeEditorSettings codeEditorSettings,
        RectTransform content,
        RectTransform areaVoidstart,
        RectTransform blockVoidupdate,
        RectTransform areaVoidupdate
        )
    {
        codeEditor = new(
            codeEditorSettings,
            content,
            areaVoidstart,
            blockVoidupdate,
            areaVoidupdate
            );
    }

    public void Update()
    {
        codeEditor.Update();


    }
}
