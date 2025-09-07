using System.Collections.Generic;
using Vector2Int = UnityEngine.Vector2Int;

using UnityLike.Entities.Compiler;
using UnityLike.Entities.Symbol;
using UnityLike.UseCases.Interpreter;
using UnityLike.InterfaceAdapters.CodeEditorMouseOver;
using UnityLike.UseCases.UnityComponent;

namespace UnityLike.InterfaceAdapters.CodeManagement
{
    public class CodeManager : ICodeChanged
    {
        private readonly CompileManager compile;
        private readonly CompileData data;
        private readonly Interpreter interpreter;
        private readonly SyncUnityComponent unityComponent;
        private readonly CodeErrorPopup errorPopup;

        public CodeManager(ISetTextUI setTextUI, IPopupView popup, UnityEngine.GameObject gameObject)
        {
            compile = new CompileManager(setTextUI);
            data = new CompileData();
            interpreter = new Interpreter();
            unityComponent = new SyncUnityComponent(gameObject);
            errorPopup = new CodeErrorPopup(data, popup);
        }

        public void OnChangeCode(string sourceCode, bool isVoidStart)
        {
            compile.Execute(sourceCode, data);

            List<Variable> initalMember = unityComponent.GetVariables();
            ExecutionMode mode = isVoidStart ? ExecutionMode.InitalExecution : ExecutionMode.SemanticAnalysisOnly;
            interpreter.ExecuteCode(data.AST, initalMember, mode);

            unityComponent.RenderUnityComponent();

            compile.RenderText(data);
        }

        public void ExecuteCode()
        {
            List<Variable> initalMember = unityComponent.GetVariables();
            interpreter.ExecuteCode(data.AST, initalMember, ExecutionMode.FullExecution);

            unityComponent.RenderUnityComponent();

            compile.RenderText(data);
        }

        public void PopupRequired(Vector2Int textPos)
        {
            if (errorPopup == null)
                UnityEngine.Debug.LogError("errorPopupÇ™ãÛÇ≈Ç∑");
            errorPopup.MessagePopUp(textPos.x, textPos.y);
        }

        /// <summary>
        /// CodeManagerÇ™ï€éùÇ∑ÇÈCompileDataÇéÊìæÇµÇ‹Ç∑
        /// </summary>
        /// <returns></returns>
        public CompileData GetCompileData()
        {
            return data;
        }
    }
}
