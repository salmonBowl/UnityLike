using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.UseCases.Compiler
{
    public partial class SemanticAnalyzer : ISemanticAnalyzer
    {
        private readonly List<SemanticErrorException> errors = new();
        private SymbolTable currentScope;
        
        public SemanticAnalyzer()
        {
            currentScope = new(null);
        }

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
