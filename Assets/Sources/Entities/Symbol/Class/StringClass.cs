using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class StringClass : Class
    {
        public static Vector3Class Single => new();

        public override Instance GetInitalInstance()
        {
            return new Vector3Instance(0, 0, 0);
        }

        public override void TryMemberExists(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
    }
}
