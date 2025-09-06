using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class TransformClass : Component
    {
        public override string Name { get; } = "Transform";
        public override System.Type Type => typeof(TransformInstance);
        public static TransformClass Single => new();

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
