using Constants;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public static class Protocol
    {
        public static async Task<string> ReceiveAsync(NetworkStream stream)
        {
            EditorLog.Message("Receive Message");
            var buffer = new byte[1024];
            var rcvMessage = "";

            while (true)
            {
                var bytesCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesCount <= 0)
                {
                    EditorLog.Message("接続がキャンセルされました");
                    break;
                }

                rcvMessage = Encoding.UTF8.GetString(buffer, 0, bytesCount);
                EditorLog.Message($"Receive {rcvMessage}");
            }
            return rcvMessage;
        }

        public static async void SendAsync(NetworkStream stream, string message)
        {
            var sendBytes = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(sendBytes, 0, sendBytes.Length);

            EditorLog.Message("Send Success");
        }

        private static string Encryption(string message)
        {
            var encryptedMessage = "";

            return encryptedMessage;
        }

        private static string Decryption(int key)
        {
            var decryptedMessage = "";

            return decryptedMessage;
        }
    }
}
