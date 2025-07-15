using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Controller
{
    public interface IGetInputFieldText
    {
        string GetInputFieldText(CodeEditorBlock block);
    }

}