using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class RigidbodyClass : Component
    {
        public override string Name { get; } = "Rigidbody";
        public override System.Type Type => typeof(RigidbodyInstance);
        public static RigidbodyClass Single => new();

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
