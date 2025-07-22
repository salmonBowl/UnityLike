using System.Collections.Generic;
using Zenject;

using UnityLike.Entities.CodeEditor;
using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;

namespace UnityLike.InterfaceAdapters.Presenter
{
    public class CompileManager : ICodeChangeInputPort
    {
        // アウトプット
        private readonly ISetTextUI view;

        private Lexer lexer;

        [Inject]
        public CompileManager(ISetTextUI view)
        {
            this.view = view;
        }

        // TextAreaUIから受け取ります
        public void CompileSourceCode(CodeEditorBlock block, string sourceCode)
        {
            // 準備

            lexer = new(Normalize(sourceCode));


            // コンパイル

            Token[] tokenArray = GenerateTokenArray();

            SourceCodeRebuilder rebuilder = new(tokenArray);


            // アウトプット

            rebuilder.RebuildExecute();

            string sourceCodeRebuild = rebuilder.GetSourceCodeRebuild();
            string richSourceCode = rebuilder.GetRichSourceCode();

            view.SetTextInputField(block, sourceCodeRebuild);
            view.SetViewText(block, richSourceCode);

            //int caretPosShiftCount = sourceCodeRebuild.Length - sourceCode.Length;
            //view.ShiftCaretPosition(block, caretPosShiftCount);
        }

        private string Normalize(string text)
        {
            // TMPでは"\\\\"が\として表示されます
            // "\\\\"("\\\\"をInputField上で消去しようとしたもの)は消去
            string backSlashProcessed = text
                .Replace("\\\\", "\v")  // \\を仮置き
                .Replace("\\", "")     // \を消去
                .Replace("\v", "\\"); // 仮置きを\\に戻す

            string normalizedSourceCode = backSlashProcessed.Replace("\r\n", "\n");
            return normalizedSourceCode;
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