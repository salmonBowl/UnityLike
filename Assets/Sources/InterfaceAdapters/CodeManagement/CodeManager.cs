using UnityLike.Entities.Compiler;
using UnityLike.InterfaceAdapters.CodeEditorMouseOver;

namespace UnityLike.InterfaceAdapters.CodeManagement
{
    public class CodeManager : ICodeChanged
    {
        private readonly CompileManager compile;
        private readonly CodeErrorPopup errorPopup;
        private CompileData data;

        public CodeManager(ISetTextUI setTextUI, IPopupView popup)
        {
            compile = new CompileManager(setTextUI);
            data = new CompileData();
            errorPopup = new CodeErrorPopup(data, popup);
        }

        public void OnChangeCode(string sourceCode)
        {
            compile.Execute(sourceCode, ref data);
        }

        /// <summary>
        /// CodeManager‚ª•Û‚·‚éCompileData‚ğæ“¾‚µ‚Ü‚·
        /// </summary>
        /// <returns></returns>
        public CompileData GetCompileData()
        {
            return data;
        }
    }
}
