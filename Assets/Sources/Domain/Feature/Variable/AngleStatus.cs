namespace UnityLike
{
    public class AngleStatus
    {
        private Angle angle;

        public AngleStatus(AngleUnit angleUnit)
        {
            angle = new Angle(0, angleUnit);
        }

        public void SetAngle(Angle newAngle)
        {
            angle = newAngle;
        }

        public Angle CurrentAngle() => angle;
    }
}
