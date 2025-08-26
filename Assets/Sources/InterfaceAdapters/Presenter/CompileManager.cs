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
        private Parser parser;

        [Inject]
        public CompileManager(ISetTextUI view)
        {
            this.view = view;
        }

        // TextAreaUIから受け取ります
        public void CompileSourceCode(CodeEditorBlock block, string sourceCode)
        {
            // InputField内のテキストを正しい形へと修正します
            FixInputFieldText(block, sourceCode);

            // 以下コンパイルを行っていきます
            /*
             * 設計の再考により実際の処理はコンパイラではなくインタプリタという形に変更されました。
             * 元のコードの名残でCompileという表現が使われています
            */

            // トークン解析
            lexer = new(Normalize(sourceCode));
            Token[] tokenArray = GenerateTokenArray();

              // 試験的にシンタックスハイライト化したものをテキストエディタ上で表示しています
            SourceCodeRebuilder rebuilder = new RebuilderFromTokens(tokenArray);
            rebuilder.RebuildExecute();
            string richSourceCode = rebuilder.GetRichSourceCode();
            view.SetViewText(block, richSourceCode);

            // 構文木解析
            parser = new(tokenArray);
            parser.Parse();
            List<StatementNode> statements = parser.GetParsedStatements();


        }

        /// <summary>
        /// UnityのInputField内で発生する問題、backslashの数が合わないなどを調整します
        /// </summary>
        private void FixInputFieldText(CodeEditorBlock block, string sourceCode)
        {
            // TMPでは"\\\\"が\として表示されます
            // "\\"("\\\\"をInputField上で消去しようとしたもの)は消去
            string backSlashProcessed = sourceCode
                .Replace("\\\\", "\v")  // \\を仮置き
                .Replace("\\", "")     // \を消去
                .Replace("\v", "\\"); // 仮置きを\\に戻す

            // InputFieldの内容を書き換えます
            view.SetTextInputField(block, backSlashProcessed);
        }
        private string Normalize(string text)
        {
            return text.Replace("\r\n", "\n");
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