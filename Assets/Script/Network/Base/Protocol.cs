using Constants;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Network
{
    public static class Protocol
    {
        public static async Task<string[]> Receive(TcpClient client)
        {
            if (client == null) { EditorLog.Error("Client Instance not passed"); return null; }

            NetworkStream stream = client.GetStream();
            var messages = new List<string>();

            while (stream.DataAvailable)
            {
                byte[] bufferLength = new byte[4];
                await stream.ReadAsync(bufferLength, 0, bufferLength.Length);

                int msgSize = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(bufferLength, 0));
                byte[] readBuffer = new byte[msgSize];
                await stream.ReadAsync(readBuffer, 0, readBuffer.Length);

                string msgStr = Encoding.UTF8.GetString(readBuffer, 0, readBuffer.Length);
                messages.Add(msgStr);
            }

            return messages.ToArray();
        }

        public static async void Send(TcpClient client, string message)
        {
            if (client == null) { EditorLog.Error("Client Instance not passed"); return; }

            NetworkStream stream = client.GetStream();

            byte[] writeBuffer = Encoding.UTF8.GetBytes(message);
            int msgSize = writeBuffer.Length;
            byte[] bufferLength = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(msgSize));

            await stream.WriteAsync(bufferLength, 0, bufferLength.Length);
            await stream.WriteAsync(writeBuffer, 0, msgSize);
        }
    }
}
