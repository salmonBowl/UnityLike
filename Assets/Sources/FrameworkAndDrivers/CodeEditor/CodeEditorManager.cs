using UnityEngine;

using UnityLike.InterfaceAdapters.CodeEditorInputManagement;
using UnityLike.InterfaceAdapters.CodeManagement;

namespace UnityLike.FrameworkAndDrivers.CodeEditor
{
    [RequireComponent(typeof(CodeEditorUIEvents), typeof(CodeEditorLayout), typeof(UIPosCalculator))]
    public class CodeEditorManager : MonoBehaviour
    {
        [SerializeField]
        private NameFieldUI InputFieldObjectName;
        [SerializeField]
        private InputFieldUI InputFieldVoidstart;
        [SerializeField]
        private InputFieldUI InputFieldVoidupdate;

        private CodeEditorUIEvents codeEditorUIEvents;
        private CodeEditorLayout codeEditorLayout;
        private UIPosCalculator codeEditorUICalculator;
        private CodeEditorInputManager inputManager;
        private InitalMemberManager initalMemberManager;

        public void ExecuteVoidStart(bool onStopped)
        {
            InputFieldVoidstart.ExecuteCode(true, onStopped);
        }
        public void ExecuteVoidUpdate()
        {
            InputFieldVoidupdate.ExecuteCode(false, false);
        }

        void Awake()
        {
            InputFieldVoidstart.AttachmentInspection();
            InputFieldVoidupdate.AttachmentInspection();

            MemberInitialize();
        }
        void Update()
        {
            InputFieldVoidstart.HidePopup();

            InputFieldVoidstart.Update();
            InputFieldVoidupdate.Update();
        }

        public void SetNameInputField(string name) => InputFieldObjectName.SetName(name);
        public void SetCodeVoidStart(string sourceCode) => codeEditorUIEvents.OnCodeChangedVoidstart(sourceCode);
        public void SetCodeVoidUpdate(string sourceCode) => codeEditorUIEvents.OnCodeChangedVoidupdate(sourceCode);
        public string GetCodeVoidStart() => InputFieldVoidstart.GetInputFieldText();
        public string GetCodeVoidUpdate() => InputFieldVoidupdate.GetInputFieldText();

        private void MemberInitialize()
        {
            codeEditorUIEvents = GetComponent<CodeEditorUIEvents>();
            codeEditorLayout = GetComponent<CodeEditorLayout>();
            codeEditorUICalculator = GetComponent<UIPosCalculator>();

            GameObject gameObject = GetComponentInParent<GameObjectManagement.GameObjectPrefab>().gameObject;
            initalMemberManager = new(gameObject);
            InputFieldVoidstart.MemberInitialize(initalMemberManager);
            InputFieldVoidupdate.MemberInitialize(initalMemberManager);

            inputManager = new CodeEditorInputManager(codeEditorLayout,
                InputFieldVoidstart.codeManager, InputFieldVoidupdate.codeManager);

            codeEditorUIEvents.DIInputManager(inputManager);
            InputFieldVoidstart.DIMousePos(codeEditorUICalculator);
            InputFieldVoidupdate.DIMousePos(codeEditorUICalculator);
        }
    }
}