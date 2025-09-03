using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class TransformClass : Class
    {
        public override string Name { get; } = "Transform";
        public static TransformClass Single => new();

        public override Instance GetInitalInstance()
        {
            Vector3Instance position = new(0, 0, 0);
            Vector3Instance eulerAngles = new(0, 0, 0);
            Vector3Instance localScale = new(0, 0, 0);
            return new TransformInstance(position, eulerAngles, localScale);
        }

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken[] argTokens, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
