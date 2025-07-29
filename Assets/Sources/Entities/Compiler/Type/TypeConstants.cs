
using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    public class TypeConstants
    {
        public static Dictionary<string, TypeBase> Types = new()
        {
            { "int", new PrimitiveType("int") },
            { "float", new PrimitiveType("float") },
            { "bool", new PrimitiveType("bool") },
            { "void", new PrimitiveType("void") },
            { "string", new PrimitiveType("string") },
        };
    }
}
