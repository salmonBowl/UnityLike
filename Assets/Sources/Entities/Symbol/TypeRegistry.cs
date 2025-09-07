using System.Collections.Generic;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class TypeRegistry
    {
        private static readonly Dictionary<string, Class> declarationTypeDictionary = new()
        {
            { "int", IntClass.Single },
            { "float", FloatClass.Single },
            { "bool", BoolClass.Single },
            { "string", StringClass.Single },

            { "Vector3", Vector3Class.Single },
        };
        private static readonly Dictionary<string, Class> staticMethodTypeDictionary = new()
        {
            { "int", IntClass.Single },
            { "float", FloatClass.Single },
            { "bool", BoolClass.Single },
            { "string", StringClass.Single },
            { "Vectot3", Vector3Class.Single },
            { "KeyCode", KeyCodeClass.Single },
            { "Debug", DebugClass.Single },
            { "Mathf", MathfClass.Single },
            { "Input", InputClass.Single },
            { "GameObject", GameObjectClass.Single },
            { "Transform", TransformClass.Single },
            { "Rigidbody", RigidbodyClass.Single },
        };

        /// <summary>
        /// dictionaryÇéQè∆ÇµÇ‹Ç∑
        /// </summary>
        /// <returns>typeÇ…ëŒâûÇ∑ÇÈClassÇï‘ÇµÇ‹Ç∑</returns>
        /// <exception cref="TypeNotRegistryException"></exception>
        public static Class DeclarationTypeOf(string type, ColoredToken token)
        {
            if (declarationTypeDictionary.TryGetValue(type, out var result))
            {
                return result;
            }
            else
            {
                throw new TypeNotRegistryException(type, token);
            }
        }
        /// <summary>
        /// dictionaryÇéQè∆ÇµÇ‹Ç∑
        /// </summary>
        /// <returns>typeÇ…ëŒâûÇ∑ÇÈClassÇï‘ÇµÇ‹Ç∑</returns>
        /// <exception cref="TypeNotRegistryException"></exception>
        public static Class StaticMethodTypeOf(string type, ColoredToken token)
        {
            if (staticMethodTypeDictionary.TryGetValue(type, out var result))
            {
                return result;
            }
            else
            {
                throw new TypeNotRegistryException(type, token);
            }
        }
    }
}
