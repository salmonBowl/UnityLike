using System;

using UnityLike.Entities.CodeEditor;
using UnityLike.InterfaceAdapters.TextAreaLayout;
using UnityLike.InterfaceAdapters.CodeManagement;

namespace UnityLike.InterfaceAdapters.CodeEditorInputManagement
{
    public class CodeEditorInputManager
    {
        private readonly TextAreaLayoutAdjust textAreaLayoutAdjust;
        private readonly ICodeChanged codeChangeVoidstart;
        private readonly ICodeChanged codeChangeVoidupdate;

        public CodeEditorInputManager(ITextAreaView textAreaView, ICodeChanged codeChangeVoidstart, ICodeChanged codeChangeVoidupdate)
        {
            textAreaLayoutAdjust = new(textAreaView);
            this.codeChangeVoidstart = codeChangeVoidstart;
            this.codeChangeVoidupdate = codeChangeVoidupdate;
        }

        public void OnTextChanged(CodeEditorBlock block, string newText)
        {
            // レイアウトの変更をします
            textAreaLayoutAdjust.Execute(block, newText);

            // ソースコードの解析を行います
            switch (block)
            {
                case CodeEditorBlock.VoidStart: codeChangeVoidstart.OnChangeCode(newText); break;
                case CodeEditorBlock.VoidUpdate: codeChangeVoidupdate.OnChangeCode(newText); break;
                default: throw new NotImplementedException();
            }
        }
    }
}
