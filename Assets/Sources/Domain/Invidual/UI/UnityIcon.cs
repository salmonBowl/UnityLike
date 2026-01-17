namespace UnityLike
{
    public class UnityIcon
    {
        AngleStatus angleStatus = new();
        AngularVelocityStatus angularVelocityStatus = new();

        public void Update()
        {


            angleStatus.Rotate();
        }

        public void GetAngle() => angleStatus.Current();
    }
    public class UnityIconScope : ScopeBase
    {

    }
}
