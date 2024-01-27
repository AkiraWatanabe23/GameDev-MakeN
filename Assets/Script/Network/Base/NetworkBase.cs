namespace Network
{
    public abstract class NetworkBase
    {
        public virtual void SystemSetUp() { }
        public virtual void OnUpdate() { }
        public virtual void OnDestroy() { }
    }
}
