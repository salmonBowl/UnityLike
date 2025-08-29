using System;

namespace UnityLike.Entities.Compiler
{
    public class CompileException : Exception { }

    // 構文解析
    public class SyntaxErrorException : CompileException
    {
        public override string Message { get; }
        public SyntaxErrorException(string errorMessage = "")
        {
            Message = errorMessage;
        }
    }

    // 意味解析
    /// <summary>
    /// 意味解析エラーの基底クラスです
    /// </summary>
    public class SemanticErrorException : CompileException { }

    public class ReDefinitionException : SemanticErrorException
    {
        public override string Message { get; }
        public ReDefinitionException(string identifierName)
        {
            Message = $"'{identifierName}'は既に定義されています";
        }
    }
    public class TypeNotFoundException : SemanticErrorException
    {
        public override string Message { get; }
        public TypeNotFoundException(string typeName)
        {
            Message = $"型名'{typeName}'は存在しません";
        }
    }
    public class IdentifierNotFoundException : SemanticErrorException
    {
        public override string Message { get; }
        public IdentifierNotFoundException(string typeName)
        {
            Message = $"'{typeName}'は定義されていません";
        }
    }
}
