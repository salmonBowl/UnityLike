using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    /// <summary>
    /// new式でのインスタンス生成に使用します。new式の形をNewという仮想のインスタンスのメンバー関数だと見立てる設計を取りました。
    /// </summary>
    public class NewInstance : NonOperationInstance
    {
        public override Class Type => throw new System.NotImplementedException();

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
                case "Vector3":
                    ArgCheck("float", "float", "float");
                    float x = ((NumberInstance)args[0]).AsFloat();
                    float y = ((NumberInstance)args[1]).AsFloat();
                    float z = ((NumberInstance)args[2]).AsFloat();
                    return new Vector3Instance(x, y, z);
                default:
                    throw new InvalidNewException(name, nameToken);
            }
        }
    }
}
