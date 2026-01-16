using System.Collections.Generic;
using Zenject;

using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;

namespace UnityLike.InterfaceAdapters.CodeManagement
{
    public class CompileManager
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

        /// <summary>
        /// コンパイルを行います
        /// </summary>
        /// <param name="block"></param>
        /// <param name="sourceCode"></param>
        public void Execute(string sourceCode, CompileData saveTarget)
        {
            // InputField内のテキストを正しい形へと修正します
            string fixedSourceCode = FixInputFieldText(sourceCode);

            // 以下コンパイルを行っていきます
            /*
             * 設計の再考により実際の処理はコンパイラではなくインタプリタという形に変更されました。
             * 元のコードの名残でCompileという表現が使われています
            */

            // トークン解析
            lexer = new(Normalize(fixedSourceCode));
            Token[] tokenArray = GenerateTokenArray();

            // 構文木解析
            parser = new(tokenArray);
            parser.Parse();
            List<StatementNode> statements = parser.GetParsedStatements();


            // コンパイルしたデータを保存します
            saveTarget.AST = statements;
        }
        public void RenderText(CompileData data)
        {
            // ソースコードを色を付けながら再構成します
            RebuilderFromAST rebuilder = new(data.AST);
            rebuilder.RebuildExecute();

            // リビルドしたデータを保存します
            data.ColoredTokens = rebuilder.GenerateTokenList.GetData();

            // ソースコードを描画します
            string richSourceCode = rebuilder.GetRichSourceCode();
            view.SetViewText(richSourceCode);
        }

        /// <summary>
        /// UnityのInputField内で発生する問題、backslashの数が合わないなどを調整します
        /// </summary>
        /// <returns>調整後のInputFieldのテキストを返します</returns>
        private string FixInputFieldText(string sourceCode)
        {
            // TMPでは"\\\\"が\として表示されます
            // "\\"("\\\\"をInputField上で消去しようとしたもの)は消去
            string backSlashProcessed = sourceCode
                .Replace("\\\\", "\v")  // \\を仮置き
                .Replace("\\", "")     // \を消去
                .Replace("\v", "\\\\"); // 仮置きを\\に戻す

            // InputFieldの内容を書き換えます
            view.SetTextInputField(backSlashProcessed);

            // 調整後のInputFieldのテキストを返します
            return backSlashProcessed;
        }
        private string Normalize(string text)
        {
            return text.Replace("\r\n", "\n").Replace("\r", "").Replace("\\\\", "\\");
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
