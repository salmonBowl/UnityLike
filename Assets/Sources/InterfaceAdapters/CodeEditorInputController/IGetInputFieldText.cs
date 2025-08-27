using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.CodeEditorInputController
{
    public interface IGetInputFieldText
    {
        string GetInputFieldText(CodeEditorBlock block);
    }

}