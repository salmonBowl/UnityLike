namespace UnityLike
{
    public class ActiveStatus
    {
        private bool isActive;

        public void Active() => isActive = true;

        public void InActive() => isActive = false;

        public bool Current() => isActive;
    }
}
