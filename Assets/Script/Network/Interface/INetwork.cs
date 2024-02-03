using System.Net;

namespace Network
{
    public interface INetwork
    {
        public bool IsConnected { get; }
        public NetworkBase Network { get; set; }

        public void Initialize();
        public void OnDestroy();
    }
}
