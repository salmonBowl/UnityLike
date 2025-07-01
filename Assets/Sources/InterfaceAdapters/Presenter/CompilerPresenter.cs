using System;
using System.Collections.Generic;
using Zenject;

using UnityLike.Entities.CodeEditor;
using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public class CompilerPresenter : ICodeChangeInputPort
    {
        /*
         * Inject����Ȃ�! �Ԉ���Ă܂���
        private readonly SourceCodeRebuilder rebuilder;

        [Inject]
        public CodeEditorPresenter(Lexer lexer, SourceCodeRebuilder rebuilder)
        {
            this.lexer = lexer;
            this.rebuilder = rebuilder;
        }
        */

        // �A�E�g�v�b�g
        private readonly ISyntaxTextView view;

        private Lexer lexer;
        public event Action<CodeEditorBlock, string> OnCompiled;

        [Inject]
        public CompilerPresenter(ISyntaxTextView view)
        {
            this.view = view;
        }

        public void OnCodeChanged(CodeEditorBlock block, string sourceCode)
        {
            string normalizedSourceCode = sourceCode.Replace("\r\n", "\n");
            lexer = new(normalizedSourceCode);

            Token[] tokenArray = GenerateTokenArray();

            SourceCodeRebuilder rebuilder = new(tokenArray);

            rebuilder.RebuildExecute();

            //string sourceCodeRebuild = rebuilder.GetSourceCodeRebuild();
            string richSourceCode = rebuilder.GetRichSourceCode();

            view.SetViewText(block, richSourceCode);
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