using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Controller
{
    public interface ICodeChangeInputPort
    {
        void HandleCodeChanged(CodeEditorBlock block, string sourceCode);
    }
}