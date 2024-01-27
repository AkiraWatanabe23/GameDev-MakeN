using UnityEngine;

namespace Network
{
    public class ConnectionSystem
    {
        private ConnectionData _connectionData = default;

        public ConnectionData CreateInstance() => _connectionData = new();

        public string Serialize() => JsonUtility.ToJson(_connectionData);

        public void Deserialize(string json) => JsonUtility.FromJsonOverwrite(json, _connectionData);
    }
}
