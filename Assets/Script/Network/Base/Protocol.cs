using Constants;
using System.Net.Sockets;
using System.Text;

namespace Network
{
    public static class Protocol
    {
        public static async void ReceiveAsync(NetworkStream stream)
        {
            var buffer = new byte[1024];

            while (true)
            {
                var bytesCount = await stream.ReadAsync(buffer, 0, buffer.Length);
                if (bytesCount <= 0)
                {
                    EditorLog.Message("接続がキャンセルされました");
                    break;
                }

                var rcvMessage = Encoding.UTF8.GetString(buffer, 0, bytesCount);
                stream.Write(buffer, 0, bytesCount);
                EditorLog.Message(rcvMessage);
            }
        }

        public static async void SendAsync(NetworkStream stream, string message)
        {
            var sendBytes = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(sendBytes, 0, sendBytes.Length);

            //await Task.Delay(1000);
            //SendAsync(stream, "Connect");
        }
    }
}
