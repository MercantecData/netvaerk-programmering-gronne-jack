using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Async
{
    class Program
    {
        static void Main(string[] args)
        {
            
            while (true)
            {
                TcpClient client = new TcpClient();

                int port = 42069;
                IPAddress ip = IPAddress.Parse("172.16.241.96");
                IPEndPoint endPoint = new IPEndPoint(ip, port);

                client.Connect(endPoint);

                NetworkStream stream = client.GetStream();
                ReceiveMessage(stream);

                Console.Write("Write a message: ");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);
            }
        }
        static async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[256];

            int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 256);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

            Console.Write("\n" + receivedMessage);
        }
    }
}
