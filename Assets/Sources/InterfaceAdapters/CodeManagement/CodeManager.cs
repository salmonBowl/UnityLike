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
        private readonly InitalMemberManager initialMemberManager;
        private readonly SyncUnityComponent unityComponent;
        private readonly CodeErrorPopup errorPopup;

        public CodeManager(ISetTextUI setTextUI, IPopupView popup, InitalMemberManager initialMemberManager)
        {
            compile = new CompileManager(setTextUI);
            data = new CompileData();
            interpreter = new Interpreter();
            this.initialMemberManager = initialMemberManager;
            unityComponent = initialMemberManager.UnityComponent;
            errorPopup = new CodeErrorPopup(data, popup);
        }

        public void OnChangeCode(string sourceCode, bool isVoidStart)
        {
            compile.Execute(sourceCode, data);

            if (isVoidStart)
            {
                initialMemberManager.InitializeList();
                List<Variable> initalMember = initialMemberManager.GetList();

                interpreter.ExecuteCode(data.AST, initalMember, ExecutionMode.InitalExecution);

                initialMemberManager.SetList(interpreter.GetVariables());
            }
            else
            {
                List<Variable> initalMember = initialMemberManager.GetList();
                interpreter.ExecuteCode(data.AST, initalMember, ExecutionMode.SemanticAnalysisOnly);
            }

            unityComponent.RenderUnityComponent();

            compile.RenderText(data);
        }

        public void ExecuteCode(bool isVoidStart)
        {
            if (isVoidStart)
            {
                initialMemberManager.InitializeList();
                List<Variable> initalMember = initialMemberManager.GetList();

                interpreter.ExecuteCode(data.AST, initalMember, ExecutionMode.FullExecution);

                initialMemberManager.SetList(interpreter.GetVariables());
            }
            else
            {
                List<Variable> initalMember = initialMemberManager.GetList();
                interpreter.ExecuteCode(data.AST, initalMember, ExecutionMode.FullExecution);
            }

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
