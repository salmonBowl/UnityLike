using UnityEngine;

using UnityLike.InterfaceAdapters.CodeEditorInputManagement;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    [RequireComponent(typeof(CodeEditorUIEvents), typeof(CodeEditorLayout), typeof(UIPosCalculator))]
    public partial class CodeEditorManager : MonoBehaviour
    {
        [SerializeField]
        private InputFieldUI InputFieldVoidstart;
        [SerializeField]
        private InputFieldUI InputFieldVoidupdate;

        private CodeEditorUIEvents codeEditorUIEvents;
        private CodeEditorLayout codeEditorLayout;
        private UIPosCalculator codeEditorUICalculator;
        private CodeEditorInputManager inputManager;

        public void ExecuteVoidStart()
        {
            InputFieldVoidstart.ExecuteCode();
        }
        public void ExecuteVoidUpdate()
        {
            InputFieldVoidupdate.ExecuteCode();
        }

        void Start()
        {
            InputFieldVoidstart.AttachmentInspection();
            InputFieldVoidupdate.AttachmentInspection();

            MemberInitialize();

            CodeInitialize();
        }
        void Update()
        {
            InputFieldVoidstart.HidePopup();

            InputFieldVoidstart.Update();
            InputFieldVoidupdate.Update();
        }

        private void MemberInitialize()
        {
            codeEditorUIEvents = GetComponent<CodeEditorUIEvents>();
            codeEditorLayout = GetComponent<CodeEditorLayout>();
            codeEditorUICalculator = GetComponent<UIPosCalculator>();

            InputFieldVoidstart.MemberInitialize();
            InputFieldVoidupdate.MemberInitialize();

            inputManager = new CodeEditorInputManager(codeEditorLayout,
                InputFieldVoidstart.codeManager, InputFieldVoidupdate.codeManager);

            codeEditorUIEvents.DIInputManager(inputManager);
            InputFieldVoidstart.DIMousePos(codeEditorUICalculator);
            InputFieldVoidupdate.DIMousePos(codeEditorUICalculator);
        }
        private void CodeInitialize()
        {
            string textVoidstart = InputFieldVoidstart.GetInputFieldText();
            string textVoidupdate = InputFieldVoidstart.GetInputFieldText();

            codeEditorUIEvents.OnCodeChangedVoidstart(textVoidstart);
            codeEditorUIEvents.OnCodeChangedVoidupdate(textVoidupdate);
        }
    }
}