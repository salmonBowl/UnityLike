using System;
using System.Collections.Generic;

namespace UnityLike.Entities.Symbol
{
    public class TypeCastConstants
    {
        public static Type TypeOf(string type)
        {
            if (typeDictionary.TryGetValue(type, out var result))
            {
                return result;
            }
            else
            {
                throw new KeyNotFoundException($"å^'{type}'Ç™ê›íËÇ≥ÇÍÇƒÇ¢Ç‹ÇπÇÒ");
            }
        }

        private static readonly Dictionary<string, Type> typeDictionary = new()
        {
            { "float", typeof(NumberInstance) },
            { "int", typeof(IntInstance) },
            { "bool", typeof(BoolInstance) },
            { "string", typeof(StringInstance) },
            { "Vector3", typeof(Vector3Instance) },
        };
    }
}
