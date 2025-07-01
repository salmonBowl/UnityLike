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
        // アウトプット
        private readonly ISyntaxTextView view;

        private Lexer lexer;

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
            tokenList.Add(currentToken); // EOFトークンも必要なので追加

            return tokenList.ToArray();
        }
    }
}