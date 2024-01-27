using UnityEngine;

namespace Network
{
    [CreateAssetMenu(fileName = "ConnectionData", menuName = "ScriptableObjects/Create ConnectionDataAsset")]
    public class ConnectionData : ScriptableObject
    {
        [field: SerializeField]
        public string IPAddress { get; set; }
        [field: SerializeField]
        public int Port { get; set; }
        [field: SerializeField]
        public string SessionID { get; set; }
    }
}
