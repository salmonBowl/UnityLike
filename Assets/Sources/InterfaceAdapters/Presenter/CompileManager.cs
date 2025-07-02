using System.Collections.Generic;
using Zenject;

using UnityLike.Entities.CodeEditor;
using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public class CompileManager : ICodeChangeInputPort
    {
        // �A�E�g�v�b�g
        private readonly ISetTextUI view;

        private Lexer lexer;

        [Inject]
        public CompileManager(ISetTextUI view)
        {
            this.view = view;
        }

        public void OnCodeChanged(CodeEditorBlock block, string sourceCode)
        {
            string normalizedSourceCode = sourceCode.Replace("\r\n", "\n").Replace("\\\\", "\\");
            lexer = new(normalizedSourceCode);


            // �R���p�C��

            Token[] tokenArray = GenerateTokenArray();

            SourceCodeRebuilder rebuilder = new(tokenArray);


            // �A�E�g�v�b�g

            rebuilder.RebuildExecute();

            string sourceCodeRebuild = rebuilder.GetSourceCodeRebuild();
            string richSourceCode = rebuilder.GetRichSourceCode();

            view.SetTextInputField(block, sourceCodeRebuild);
            view.SetViewText(block, richSourceCode);

            int caretPosShiftCount = sourceCodeRebuild.Length - sourceCode.Length;
            //view.ShiftCaretPosition(block, caretPosShiftCount);
        }

        private Token[] GenerateTokenArray()
        {
            List<Token> tokenList = new();
            Token currentToken;

            while ((currentToken = lexer.GetNextToken()).TokenType != TokenType.EOF)
            {
                tokenList.Add(currentToken);
            }
            tokenList.Add(currentToken); // EOF�g�[�N�����K�v�Ȃ̂Œǉ�

            return tokenList.ToArray();
        }
    }
}