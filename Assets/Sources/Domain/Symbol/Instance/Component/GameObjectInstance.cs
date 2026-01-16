using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class GameObjectInstance : NonOperationInstance
    {
        public override Class Type => GameObjectClass.Single;

        public GameObjectInstance(Variable transform, Variable rigidBody)
        {
            Variable ActiveSelf = new("activeSelf", BoolClass.Single);

            Member.AddMember(transform, rigidBody, ActiveSelf);

            ActiveSelf.Value = new BoolInstance(true);
        }

        public override Instance ExecuteMemberFuction(string name, Instance[] args, ColoredToken nameToken, ColoredToken rightParen)
        {
            void ArgCheck(params string[] expected)
            {
                int argCount = expected.Length;
                if (args.Length != argCount)
                {
                    throw new InvalidArgumentException(expected.Length, rightParen);
                }
                for (int i = 0; i < argCount; i++)
                {
                    if (!Castable(args[i], expected[i]))
                    {
                        throw new ArgumentInvalidTypeException(expected[i], nameToken);
                    }
                }
            }

            switch (name)
            {
                case "SetActive":
                    ArgCheck("bool");
                    bool value = ((BoolInstance)args[0]).AsBool();
                    SetMember("activeSelf", new BoolInstance(value));
                    return null;
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
