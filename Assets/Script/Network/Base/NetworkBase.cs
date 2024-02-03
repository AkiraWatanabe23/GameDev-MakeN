using System.Net.Sockets;

namespace Network
{
    public abstract class NetworkBase
    {
        public abstract NetworkStream Stream { get; }
        public abstract bool IsConnected { get; }

        public virtual void DisConnected() { }
        public virtual void OnDestroy() { }
    }
}
