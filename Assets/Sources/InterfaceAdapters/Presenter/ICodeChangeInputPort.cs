using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public interface ICodeChangeInputPort
    {
        void CompileSourceCode(CodeEditorBlock block, string sourceCode);
    }
}