using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.CompileManager
{
    public interface ICodeChangeInputPort
    {
        void CompileSourceCode(CodeEditorBlock block, string sourceCode);
    }
}