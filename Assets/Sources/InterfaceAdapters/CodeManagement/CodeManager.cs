using Vector2Int = UnityEngine.Vector2Int;

using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Interpreter;
using UnityLike.InterfaceAdapters.CodeEditorMouseOver;

namespace UnityLike.InterfaceAdapters.CodeManagement
{
    public class CodeManager : ICodeChanged
    {
        private readonly CompileManager compile;
        private readonly CompileData data;
        private readonly Interpreter interpreter = new();
        private readonly CodeErrorPopup errorPopup;

        public CodeManager(ISetTextUI setTextUI, IPopupView popup)
        {
            compile = new CompileManager(setTextUI);
            data = new CompileData();
            errorPopup = new CodeErrorPopup(data, popup);
        }

        public void OnChangeCode(string sourceCode)
        {
            compile.Execute(sourceCode, data);
            interpreter.ExecuteCode(data.AST);
            compile.RenderText(data);
        }

        public void ExecuteCode()
        {
            interpreter.ExecuteCode(data.AST);
        }

        public void PopupRequired(Vector2Int textPos)
        {
            if (errorPopup == null)
                UnityEngine.Debug.LogError("errorPopup‚ª‹ó‚Å‚·");
            errorPopup.MessagePopUp(textPos.x, textPos.y);
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
