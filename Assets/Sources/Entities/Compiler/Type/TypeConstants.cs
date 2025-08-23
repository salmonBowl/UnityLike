
using System.Collections.Generic;

namespace UnityLike.Entities.Compiler
{
    public class TypeConstants
    {
        public readonly static Dictionary<string, TypeBase> definedTypes = new()
        {
            { "int", new PrimitiveType("int") },
            { "float", new PrimitiveType("float") },
            { "bool", new PrimitiveType("bool") },
            { "void", new PrimitiveType("void") },
            { "string", new PrimitiveType("string") },
        };
        public void AddType(string typeName)
        {
            definedTypes.Add(typeName, new PrimitiveType(typeName));
        }
    }
}
