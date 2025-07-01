using System;
using Zenject;

using UnityLike.Entities.CodeEditor;
using UnityLike.UseCases.CodeEditor;
using UnityLike.InterfaceAdapters.Presenter;

namespace UnityLike.InterfaceAdapters.Controller
{
    public class CodeEditorInputController : IInitializable, IDisposable, ICodeChangeInputPort
    {
        private readonly LineCountManager lineCountManager;
        private readonly UpdateTextAreaUseCase updateTextAreaUseCase;
        private readonly ITextAreaInput textAreaInput;
        private readonly IGetInputFieldText getInputFieldText;

        private readonly CompilerPresenter compilerPresenter;

        [Inject]
        public CodeEditorInputController(
            LineCountManager lineCountManager,
            UpdateTextAreaUseCase updateTextAreaUseCase,
            ITextAreaInput textAreaInput,
            IGetInputFieldText getInputFieldText,
            CompilerPresenter compilerPresenter
            )
        {
            //UnityEngine.Debug.Log("CodeEditorInputController.Constructor()");

            this.lineCountManager = lineCountManager;
            this.updateTextAreaUseCase = updateTextAreaUseCase;
            this.textAreaInput = textAreaInput;
            this.getInputFieldText = getInputFieldText;

            this.compilerPresenter = compilerPresenter;
        }

        public void Initialize()
        {
            //UnityEngine.Debug.Log("CodeEditorInputController.Initialize()");

            if (lineCountManager == null)
                UnityEngine.Debug.LogError("CodeEditorInputController : lineCountManager���ݒ肳��Ă��܂���");
            if (updateTextAreaUseCase == null)
                UnityEngine.Debug.LogError("CodeEditorInputController : updateTextAreaUseCase���ݒ肳��Ă��܂���");
            if (textAreaInput == null)
                UnityEngine.Debug.LogError("CodeEditorInputController : textAreaInput���ݒ肳��Ă��܂���");

            // View��Controller��LineCount
            textAreaInput.OnTextAreaInputChanged += OnTextInputChanged;

            //LineCount��Controller��UseCase.Execute
            lineCountManager.OnLineCountChanged += OnLineCountChangedHandler;

            // �����\���̂��߂Ɉ�x�������s
            // VoidStart
            OnTextInputChanged(CodeEditorBlock.VoidStart, getInputFieldText.GetInputFieldText(CodeEditorBlock.VoidStart));
            // VoidUpdate
            OnTextInputChanged(CodeEditorBlock.VoidUpdate, getInputFieldText.GetInputFieldText(CodeEditorBlock.VoidUpdate));
        }
        public void Dispose()
        {
            textAreaInput.OnTextAreaInputChanged -= OnTextInputChanged;
            lineCountManager.OnLineCountChanged -= OnLineCountChangedHandler;
        }

        private void OnLineCountChangedHandler()
        {
            updateTextAreaUseCase.Execute();
        }
        private void OnTextInputChanged(CodeEditorBlock block, string newText)
        {
            //UnityEngine.Debug.Log("CodeEditorInputController | newText : " + newText);

            // InputField�̍�����ύX���܂�
            int newLineCount = CalculateLineCount(newText);
            lineCountManager.SetLineCount(block, newLineCount);

            // �ύX��ʒm���܂�
            // ����͗Ⴆ��CompilerPresenter�Ȃǂ��󂯎��܂�

            //compilerPresenter.OnCodeChanged(block, newText);
        }

        private int CalculateLineCount(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 1;

            return text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).Length;
        }
    }
}