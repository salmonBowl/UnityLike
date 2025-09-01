using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class TypeRegistry
    {
        private static readonly Dictionary<string, Class> typeDictionary = new()
        {
            { "int", IntClass.Single },
            { "float", FloatClass.Single },
            { "string", StringClass.Single },

            { "Vector3", Vector3Class.Single },
        };

        /// <summary>
        /// dictionary‚ğQÆ‚µ‚Ü‚·
        /// </summary>
        /// <returns>type‚É‘Î‰‚·‚éClass‚ğ•Ô‚µ‚Ü‚·</returns>
        /// <exception cref="TypeNotExistException"></exception>
        public static Class TypeOf(string type, ColoredToken token)
        {
            if (typeDictionary.TryGetValue(type, out var result))
            {
                return result;
            }
            else
            {
                throw new TypeNotExistException(type, token);
            }
        }
    }
}
