using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class FloatClass : Class
    {
        public static FloatClass Single => new();

        public override Instance GetInitalInstance()
        {
            return new IntInstance(0);
        }

        public override void TryMemberExists(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
    }
}
