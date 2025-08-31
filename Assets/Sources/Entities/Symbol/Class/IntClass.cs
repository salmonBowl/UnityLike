using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class IntClass : Class
    {
        public static IntClass Instance => new();

        public override string Name => "int";

        public override Instance NewInstance(params Instance[] args)
        {
            return new IntInstance();
        }

        public override void TryMemberExists(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
    }
}
