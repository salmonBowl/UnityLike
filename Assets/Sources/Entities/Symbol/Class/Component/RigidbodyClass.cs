using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class RigidbodyClass : Component
    {
        public override string Name { get; } = "Rigidbody";
        public static RigidbodyClass Single => new();

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
