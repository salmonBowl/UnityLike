using Transform = UnityEngine.Transform;
using Vector3 = UnityEngine.Vector3;
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
        public TransformInstance(Vector3Instance position, Vector3Instance eulerAngles, Vector3Instance localScale)
        {
            Class Vector3 = Vector3Class.Single;

            Variable Position = new("position", Vector3);
            Variable EulerAngles = new("eulerAngles", Vector3);
            Variable LocalScale = new("localScale", Vector3);

            Member.AddMember(Position, EulerAngles, LocalScale);

            Position.Value = position;
            EulerAngles.Value = eulerAngles;
            LocalScale.Value = localScale;
        }

        // メソッドの実装例
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

            // 関数実行のためにメンバー変数を取得しておきます
            Vector3 position = ((Vector3Instance)GetMember("position")).AsVector3();
            Vector3 eulerAngles = ((Vector3Instance)GetMember("eulerAngles")).AsVector3();
            Vector3 scale = ((Vector3Instance)GetMember("scale")).AsVector3();

            switch (name)
            {
                case "Translate":
                    ArgCheck("float", "float", "float");
                    float x = ((NumberInstance)args[0]).AsFloat();
                    float y = ((NumberInstance)args[1]).AsFloat();
                    float z = ((NumberInstance)args[2]).AsFloat();
                    Vector3 localVector = new(x, y, z);

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
