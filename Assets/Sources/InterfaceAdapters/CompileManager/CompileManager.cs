using System.Collections.Generic;
using Zenject;

using UnityLike.Entities.CodeEditor;
using UnityLike.Entities.Compiler;
using UnityLike.UseCases.Compiler;

namespace UnityLike.InterfaceAdapters.CompileManager
{
    public class CompileManager : ICodeChangeInputPort
    {
        // アウトプット
        private readonly ISetTextUI view;

        private Lexer lexer;
        private Parser parser;

        private readonly CompileData data = new();

        [Inject]
        public CompileManager(ISetTextUI view)
        {
            this.view = view;
        }

        // TextAreaUIから受け取ります
        public void CompileSourceCode(CodeEditorBlock block, string sourceCode)
        {
            // InputField内のテキストを正しい形へと修正します
            string fixedSourceCode = FixInputFieldText(block, sourceCode);

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

            // ソースコードを色を付けながら再構成し、テキストエディタへ表示します
            RebuilderFromAST rebuilder = new(statements);
            rebuilder.RebuildExecute();
            string richSourceCode = rebuilder.GetRichSourceCode();
            view.SetViewText(block, richSourceCode);

            // コンパイルしたデータを保存します
            data.ColoredTokens = rebuilder.GenerateTokenList.GetData();
            data.AST = statements;
        }

        /// <summary>
        /// CompileManagerが保持するCompileDataを取得します
        /// </summary>
        /// <returns></returns>
        public CompileData GetCompileData()
        {
            return data;
        }

        /// <summary>
        /// UnityのInputField内で発生する問題、backslashの数が合わないなどを調整します
        /// </summary>
        /// <returns>調整後のInputFieldのテキストを返します</returns>
        private string FixInputFieldText(CodeEditorBlock block, string sourceCode)
        {
            // TMPでは"\\\\"が\として表示されます
            // "\\"("\\\\"をInputField上で消去しようとしたもの)は消去
            string backSlashProcessed = sourceCode
                .Replace("\\\\", "\v")  // \\を仮置き
                .Replace("\\", "")     // \を消去
                .Replace("\v", "\\\\"); // 仮置きを\\に戻す

            // InputFieldの内容を書き換えます
            view.SetTextInputField(block, backSlashProcessed);

            // 調整後のInputFieldのテキストを返します
            return backSlashProcessed;
        }
        private string Normalize(string text)
        {
            return text.Replace("\r\n", "\n").Replace("\\\\", "\\");
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