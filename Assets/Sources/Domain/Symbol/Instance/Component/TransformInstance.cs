using UnityEngine;

using UnityLike.Entities.Compiler;

namespace UnityLike.Entities.Symbol
{
    public class TransformInstance : NonOperationInstance
    {
        public override Class Type => TransformClass.Single;

        public TransformInstance(Transform transform)
        {
            Class Vector3 = Vector3Class.Single;

            Variable Position = new("position", Vector3);
            Variable EulerAngles = new("eulerAngles", Vector3);
            Variable LocalScale = new("localScale", Vector3);

            Member.AddMember(Position, EulerAngles, LocalScale);

            Position.Value = new Vector3Instance(transform.position);
            EulerAngles.Value = new Vector3Instance(transform.eulerAngles);
            LocalScale.Value = new Vector3Instance(transform.localScale);
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
            bool IsMatchArg(params string[] expected)
            {
                int argCount = expected.Length;
                if (args.Length != argCount)
                {
                    return false;
                }
                for (int i = 0; i < argCount; i++)
                {
                    if (!Castable(args[i], expected[i]))
                    {
                        return false;
                    }
                }
                return true;
            }

            // 関数実行のためにメンバー変数を取得しておきます
            Vector3 position = ((Vector3Instance)GetMember("position")).AsVector3();
            Vector3 eulerAngles = ((Vector3Instance)GetMember("eulerAngles")).AsVector3();
            // 重複して使用する変数を宣言しておきます
            float x;
            float y;
            float z;

            switch (name)
            {
                case "Translate":
                    Vector3 localVector;
                    if (IsMatchArg("float", "float", "float"))
                    {
                        x = ((NumberInstance)args[0]).AsFloat();
                        y = ((NumberInstance)args[1]).AsFloat();
                        z = ((NumberInstance)args[2]).AsFloat();
                        localVector = new Vector3(x, y, z);
                    }
                    else if (IsMatchArg("Vector3"))
                    {
                        localVector = ((Vector3Instance)args[0]).AsVector3();
                    }
                    else
                    {
                        throw new InvalidArgumentException(3, nameToken);
                    }

                    // ローカル座標のベクトルをワールド座標に変換
                    // (簡易的な実装です。後にQuaternionに置き換えます)
                    float radianX = eulerAngles.x * Mathf.Deg2Rad;
                    float radianY = eulerAngles.y * Mathf.Deg2Rad;
                    float radianZ = eulerAngles.z * Mathf.Deg2Rad;

                    // 回転行列による変換
                    float cosY = Mathf.Cos(radianY);
                    float sinY = Mathf.Sin(radianY);
                    float cosX = Mathf.Cos(radianX);
                    float sinX = Mathf.Sin(radianX);
                    float cosZ = Mathf.Cos(radianZ);
                    float sinZ = Mathf.Sin(radianZ);

                    float newX = localVector.x * (cosY * cosZ) + localVector.y * (cosY * -sinZ) + localVector.z * sinY;
                    float newY = localVector.x * (cosX * sinZ + sinX * sinY * cosZ) + localVector.y * (cosX * cosZ - sinX * sinY * sinZ) + localVector.z * (-sinX * cosY);
                    float newZ = localVector.x * (sinX * sinZ - cosX * sinY * cosZ) + localVector.y * (sinX * cosZ + cosX * sinY * sinZ) + localVector.z * (cosX * cosY);

                    // 加算
                    Vector3 newPosition = position + new Vector3(newX, newY, newZ);

                    SetMember("position", new Vector3Instance(newPosition));
                    return null;
                case "Rotate":
                    ArgCheck("float", "float", "float");
                    x = ((NumberInstance)args[0]).AsFloat();
                    y = ((NumberInstance)args[1]).AsFloat();
                    z = ((NumberInstance)args[2]).AsFloat();
                    Vector3Instance addRotation = new(x, y, z);
                    Vector3Instance currentRotation = (Vector3Instance)GetMember("eulerAngles");
                    Vector3Instance newRotation = (Vector3Instance)currentRotation.Add(addRotation);
                    SetMember("eulerAngles", newRotation);
                    return null;
                default:
                    throw new MemberNotExistException(name, nameToken);
            }
        }
    }
}
