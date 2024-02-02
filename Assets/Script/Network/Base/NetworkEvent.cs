using System;

namespace Network
{
    [Serializable]
    public class NetworkEvent
    {
        public Action<string> OnSendData;
    }
}
