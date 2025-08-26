using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    /// <summary>
    /// 構文木を意味解析するクラスです。構文木そのものと相互作用して解析を進めるという設計をとっています。
    /// </summary>
    public partial class SemanticAnalyzer : ISemanticAnalyzer
    {
        /// <summary>
        /// 解析した文の意味上のエラーを収集します
        /// </summary>
        private readonly List<SemanticErrorException> errors = new();

        /// <summary>
        /// 現在意味解析しているスコープを示します
        /// </summary>
        private SymbolTable currentScope = new(null);
        
        /// <summary>
        /// 意味解析を終えたIdentifierの型をスタックします。これにより型比較の仕組みを作ります。
        /// </summary>
        private readonly Stack<TypeBase> typeStack = new();
        
        /// <summary>
        /// 渡した構文木を意味解析します
        /// </summary>
        /// <param name="statements">意味解析する構文木をstatementsの形式で渡します</param>
        public void Analyze(List<StatementNode> statements)
        {
            foreach (var statement in statements)
            {
                try
                {
                    statement.ASTScan(this);
                }
                catch (SemanticErrorException error)
                {
                    errors.Add(error);
                }
            }
        }
    }
}
