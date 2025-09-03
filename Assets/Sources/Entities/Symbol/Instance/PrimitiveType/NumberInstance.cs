using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public abstract class NumberInstance : PrimitiveInstance
    {
        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }

        public abstract float AsFloat(); // ”’l‚ğfloat‚Æ‚µ‚Ä•Ô‚µ‚Ü‚·
    }
}
