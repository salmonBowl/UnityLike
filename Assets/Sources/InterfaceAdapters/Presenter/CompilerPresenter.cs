using System;
using System.Collections.Generic;
using Zenject;

using UnityLike.Entities.CodeEditor;
using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;
using UnityLike.FrameworkAndDrivers.CodeEditor;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public class CompilerPresenter
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

        // �v�C���I�I�I�ꎞ�I�Ȃ��̂ł��I�I�I
        private readonly ICompilerPresenter view;

        private Lexer lexer;
        public event Action<CodeEditorBlock, string> OnCompiled;

        [Inject]
        public CompilerPresenter(ICompilerPresenter view)
        {
            this.view = view;
        }

        public void OnCodeChanged(CodeEditorBlock block, string sourceCode)
        {
            lexer = new(sourceCode);

            Token[] tokenArray = GenerateTokenArray();

            SourceCodeRebuilder rebuilder = new(tokenArray);

            rebuilder.RebuildExecute();
            //string sourceCodeRebuild = rebuilder.GetSourceCodeRebuild();
            string richSourceCode = rebuilder.GetRichSourceCode();

            // �v�C��!
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