using System;

namespace UnityLike.Entities.Compiler
{
    // \•¶‰ğÍ
    public class SyntaxErrorException : Exception { }

    // ˆÓ–¡‰ğÍ
    public class SemanticErrorException : Exception { }
    public class ReDefinitionException : SemanticErrorException { }
}