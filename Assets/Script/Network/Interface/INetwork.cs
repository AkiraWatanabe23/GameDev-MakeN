using System.Net;

namespace Network
{
    public interface INetwork
    {
        public void Initialize();

        public void OnDestroy();
    }
}
