using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class StringClass : Class
    {
        public override string Name { get; } = "string";
        public override System.Type Type => typeof(StringInstance);
        public static StringClass Single => new();

        public override Instance GetInitalInstance()
        {
            return new StringInstance("");
        }

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
