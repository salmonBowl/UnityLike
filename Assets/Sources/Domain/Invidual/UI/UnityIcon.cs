namespace UnityLike
{
    public class UnityIcon : ScopedClass
    {
        AngleStatus angleStatus = new();
        AngularVelocityStatus angularVelocityStatus = new();

        public void Update()
        {

            angleStatus.Rotate();
        }

        protected override System.Type GetScopeType() => typeof(UnityIconScope);
        public void GetAngle() => angleStatus.Current();
    }
    public class UnityIconScope : ScopeBase
    {

    }
}
