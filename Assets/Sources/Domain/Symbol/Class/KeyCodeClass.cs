using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class KeyCodeClass : Class
    {
        public override string Name { get; } = "KeyCode";
        public override System.Type Type => typeof(KeyCodeClass);
        public static KeyCodeClass Single => new();

        public override Instance GetInitalInstance()
        {
            return new KeyCodeInstance(UnityEngine.KeyCode.Mouse0);
        }

        public override Instance ExecuteStaticFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen = null)
        {
            throw new MemberNotExistException(name, nameToken);
        }
    }
}
