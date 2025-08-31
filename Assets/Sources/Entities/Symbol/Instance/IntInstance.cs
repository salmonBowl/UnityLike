
using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class IntInstance : NumberInstance
    {
        public override Class Type => IntClass.Instance;
        
        public int Value { get; set; }

        public IntInstance(int value)
        {
            Value = value;
        }

        public override Instance GetMember(string member, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }
        public override void SetMember(string member, Instance value, ColoredToken token)
        {
            throw new MemberNotExistException(member, token);
        }

        public override float AsFloat()
        {
            return Value;
        }
    }
}
