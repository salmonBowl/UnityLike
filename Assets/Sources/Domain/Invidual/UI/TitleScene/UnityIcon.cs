namespace UnityLike.UI
{
    public class UnityIcon : UIObject
    {
        private readonly AngleStatus angleStatus = new(AngleUnit.Radian);
        private readonly AngularVelocityStatus angularVelocityStatus = new(AngleUnit.Radian);

        public override void SetUp()
        {
            angleStatus.SetAngle(new Angle(0));
        }
        public override void Update()
        {

            angleStatus.Rotate();
        }

        protected override System.Type GetScopeType() => typeof(UnityIconScope);
        public Angle GetAngle() => angleStatus.CurrentAngle();
    }
    public class UnityIconScope : ScopeBase
    {

    }
}
