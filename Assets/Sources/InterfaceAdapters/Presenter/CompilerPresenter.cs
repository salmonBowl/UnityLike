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
         * Injectじゃない! 間違ってました
        private readonly SourceCodeRebuilder rebuilder;

        [Inject]
        public CodeEditorPresenter(Lexer lexer, SourceCodeRebuilder rebuilder)
        {
            this.lexer = lexer;
            this.rebuilder = rebuilder;
        }
        */

        // 要修正！！！一時的なものです！！！
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

            // 要修正!
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
            tokenList.Add(currentToken); // EOFトークンも必要なので追加

            return tokenList.ToArray();
        }
    }
}