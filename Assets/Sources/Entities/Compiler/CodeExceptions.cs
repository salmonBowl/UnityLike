using System;

namespace UnityLike.Entities.Compiler
{
    public class CodeException : Exception { }

    // --- 構文解析 ---
    public class SyntaxErrorException : CodeException
    {
        public override string Message { get; }
        public SyntaxErrorException(string errorMessage = "")
        {
            Message = errorMessage;
        }
    }

    // --- インタプリタ ---
    /// <summary>
    /// 意味解析エラーの基底クラスです
    /// </summary>
    public class SemanticErrorException : CodeException { }
    /// <summary>
    /// 実行エラーの基底クラスです
    /// </summary>
    public class ExecuteException : CodeException { }

    public class TypeNotExistException : SemanticErrorException
    {
        public override string Message { get; }
        public TypeNotExistException(string typeName, ColoredToken token)
        {
            Message = $"型名'{typeName}'は存在しません";
            token.HasError(Message);
        }
    }
    public class MemberNotExistException : SemanticErrorException
    {
        public override string Message { get; }
        public MemberNotExistException(string memberName, ColoredToken token)
        {
            Message = $"メンバー'{memberName}'は存在しません";
            token.HasError(Message);
        }
    }
    public class IdentifierNotFoundException : SemanticErrorException
    {
        public override string Message { get; }
        public IdentifierNotFoundException(string typeName, ColoredToken token)
        {
            Message = $"'{typeName}'は定義されていません";
            token.HasError(Message);
        }
    }
    public class InvalidArgumentException : SemanticErrorException
    {
        public override string Message { get; }
        public InvalidArgumentException(int argCount, ColoredToken token)
        {
            Message = $"引数の数は{argCount}にしてください";
            token.HasError(Message);
        }
    }
    public class ArgumentInvalidTypeException : SemanticErrorException
    {
        public override string Message { get; }
        public ArgumentInvalidTypeException(string expectedType, ColoredToken token)
        {
            Message = $"引数の型が間違っています。{expectedType}型のものを指定してください";
            token.HasError(Message);
        }
    }

    public class ReDefinitionException : ExecuteException
    {
        public override string Message { get; }
        public ReDefinitionException(string identifierName, ColoredToken token)
        {
            Message = $"'{identifierName}'は既に定義されています";
            token.HasError(Message);
        }
    }
}
