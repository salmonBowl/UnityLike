using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class StringInstance : PrimitiveInstance
    {
        public override Class Type => IntClass.Single;

        public StringInstance(string value)
        {
            Value = value;

            // ƒƒ“ƒo[•Ï”length‚ğ’è‹`‚µ‚Ü‚·
            Variable Length = new("length", Type);
            Member.AddMember(Length);

            Length.Value = new IntInstance(value.Length);
        }

        public string AsString()
        {
            return (string)Value;
        }

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
