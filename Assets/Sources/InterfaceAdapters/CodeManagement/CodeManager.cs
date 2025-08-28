using Vector3 = UnityEngine.Vector3;

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
            errorPopup = new CodeErrorPopup(data, popup);
            data = new CompileData();
        }

        public void OnChangeCode(string sourceCode)
        {
            compile.Execute(sourceCode, ref data);
        }

        public void PopupRequied(Vector3 localMousePos)
        {
            int x = (int)localMousePos.x;
            int y = (int)localMousePos.y;
            errorPopup.MessagePopUp(x, y);
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
