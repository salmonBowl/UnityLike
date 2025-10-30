using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// ‰‰ŽZ‚ÉŠÖ‚í‚ç‚È‚¢Œ^‚ð’è‹`‚µ‚Ü‚·
    /// </summary>
    public abstract class NonOperationInstance : Instance
    {
        public override Instance Add(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Subtract(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Multiply(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Divide(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Modulo(Instance other)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Comparison(Instance other, string @operator)
        {
            throw new InvalidOperatorException();
        }
        public override Instance Minus()
        {
            throw new InvalidOperatorException();
        }
        public override Instance Denial()
        {
            throw new InvalidOperatorException();
        }
    }
}
