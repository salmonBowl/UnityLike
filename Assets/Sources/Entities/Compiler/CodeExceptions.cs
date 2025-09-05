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
    public class FunctionNotExistException : SemanticErrorException
    {
        public override string Message { get; }
        public FunctionNotExistException(string memberName, ColoredToken token)
        {
            Message = $"メンバー関数'{memberName}'は存在しません";
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
            Message = $"引数の数が間違っています。正しくは{argCount}です";
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
    public class InvalidTokenException : SemanticErrorException
    {
        public override string Message { get; }
        public InvalidTokenException(ColoredToken token)
        {
            Message = $"無効な単語です";
            token.HasError(Message);
        }
    }
    public class InvalidOperatorException : SemanticErrorException
    {
        public override string Message { get; }
        public InvalidOperatorException()
        {
            Message = $"無効な演算子です";
        }
        public InvalidOperatorException(string message)
        {
            Message = message;
        }
        public InvalidOperatorException(ColoredToken token)
        {
            Message = $"無効な演算子です";
            token.HasError(Message);
        }
        public InvalidOperatorException(string message, ColoredToken token)
        {
            Message = message;
            token.HasError(Message);
        }
    }
    public class ConditionNotBoolException : SemanticErrorException
    {
        public override string Message { get; }
        public ConditionNotBoolException(ColoredToken token)
        {
            Message = "条件式の型はbool型にしてください";
            token.HasError(Message);
        }
    }

    // --- 実行エラー ---

    public class ReDefinitionException : ExecuteException
    {
        public override string Message { get; }
        public ReDefinitionException(string identifierName, ColoredToken token)
        {
            Message = $"'{identifierName}'は既に定義されています";
            token.HasError(Message);
        }
    }
    public class AssignmentNotIncompatibleException : ExecuteException
    {
        public override string Message { get; }
        public AssignmentNotIncompatibleException(string expectedType, string assignmentType, ColoredToken token)
        {
            Message = $"{expectedType}型の変数に{assignmentType}型の値を代入することはできません";
            token.HasError(Message);
        }
    }
    public class ParseFailedException : ExecuteException
    {
        public override string Message { get; }
        public ParseFailedException(string value, string expectedType, ColoredToken token)
        {
            Message = $"'{value}'の{expectedType}型への変換に失敗しました";
            token.HasError(Message);
        }
    }
    public class DivideByZeroExecuteException : ExecuteException
    {
        public override string Message { get; }
        public DivideByZeroExecuteException(string message, ColoredToken token)
        {
            Message = message + $"0で除算することはできません";
            token.HasError(Message);
        }
    }
    public class InfiniteLoopException : ExecuteException
    {
        public override string Message { get; }
        public InfiniteLoopException(ColoredToken token)
        {
            Message = "無限ループが発生しました";
            token.HasError(Message);
        }
    }
}
