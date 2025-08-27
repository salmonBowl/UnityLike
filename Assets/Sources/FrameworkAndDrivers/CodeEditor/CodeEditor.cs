using UnityEngine;

using UnityLike.InterfaceAdapters.CodeEditorInputManagement;
using UnityLike.InterfaceAdapters.TextAreaLayout;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    [RequireComponent(typeof(CodeEditorUIEvents), typeof(CodeEditorLayout))]
    public partial class CodeEditor : MonoBehaviour
    {
        [SerializeField]
        private InputFieldUI InputFieldVoidstart;
        [SerializeField]
        private InputFieldUI InputFieldVoidupdate;

        private readonly CodeEditorUIEvents codeEditorUIEvents;
        private readonly CodeEditorLayout codeEditorLayout;
        private readonly CodeEditorInputManager inputManager;

        private CodeEditor()
        {
            codeEditorUIEvents = GetComponent<CodeEditorUIEvents>();
            codeEditorLayout = GetComponent<CodeEditorLayout>();
            inputManager = new CodeEditorInputManager(codeEditorLayout,
                InputFieldVoidstart.codeManager, InputFieldVoidupdate.codeManager);
        }

        void Start()
        {
            InputFieldVoidstart.AttachmentInspection();
            InputFieldVoidupdate.AttachmentInspection();

            codeEditorUIEvents.SetInputManager(inputManager);
        }
    }
}