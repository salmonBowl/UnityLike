using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class BoolClass : Class
    {
        public override string Name { get; } = "bool";
        public static BoolClass Single => new();

        public override Instance GetInitalInstance()
        {
            return new BoolInstance(true);
        }

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
