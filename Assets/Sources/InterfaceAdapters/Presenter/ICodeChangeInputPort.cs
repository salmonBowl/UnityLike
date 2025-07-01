using UnityLike.Entities.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public interface ICodeChangeInputPort
    {
        void OnCodeChanged(CodeEditorBlock block, string sourceCode);
    }
}