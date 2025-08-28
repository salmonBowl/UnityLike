using UnityEngine;

using UnityLike.InterfaceAdapters.CodeEditorInputManagement;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    [RequireComponent(typeof(CodeEditorUIEvents), typeof(CodeEditorLayout))]
    public partial class CodeEditor : MonoBehaviour
    {
        [SerializeField]
        private InputFieldUI InputFieldVoidstart;
        [SerializeField]
        private InputFieldUI InputFieldVoidupdate;

        private CodeEditorUIEvents codeEditorUIEvents;
        private CodeEditorLayout codeEditorLayout;
        private CodeEditorInputManager inputManager;

        void Start()
        {
            InputFieldVoidstart.AttachmentInspection();
            InputFieldVoidupdate.AttachmentInspection();

            MemberInitialize();

            InputFieldVoidstart.Start();
            InputFieldVoidupdate.Start();

            CodeInitialize();
        }
        void Update()
        {
            InputFieldVoidstart.Update();
            InputFieldVoidupdate.Update();
        }

        private void MemberInitialize()
        {
            codeEditorUIEvents = GetComponent<CodeEditorUIEvents>();
            codeEditorLayout = GetComponent<CodeEditorLayout>();
            inputManager = new CodeEditorInputManager(codeEditorLayout,
                InputFieldVoidstart.codeManager, InputFieldVoidupdate.codeManager);

            codeEditorUIEvents.SetInputManager(inputManager);
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