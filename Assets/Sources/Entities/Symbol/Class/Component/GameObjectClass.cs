using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class GameObjectClass : Component
    {
        public override string Name { get; } = "GameObject";
        public static GameObjectClass Single => new();

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
