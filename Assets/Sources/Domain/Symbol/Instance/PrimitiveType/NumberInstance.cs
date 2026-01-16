using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public abstract class NumberInstance : PrimitiveInstance
    {
        public abstract float AsFloat(); // ”’l‚ğfloat‚Æ‚µ‚Ä•Ô‚µ‚Ü‚·

        public override Instance Comparison(Instance other, string @operator)
        {
            if (other is not NumberInstance otherNumber)
            {
                throw new InvalidOperatorException();
            }

            bool result = @operator switch
            {
                "<" => AsFloat() < otherNumber.AsFloat(),
                "<=" => AsFloat() <= otherNumber.AsFloat(),
                ">" => AsFloat() > otherNumber.AsFloat(),
                ">=" => AsFloat() >= otherNumber.AsFloat(),
                "==" => AsFloat() == otherNumber.AsFloat(),
                "!=" => AsFloat() != otherNumber.AsFloat(),
                _ => throw new InvalidOperatorException()
            };
            return new BoolInstance(result);
        }
    }
}
