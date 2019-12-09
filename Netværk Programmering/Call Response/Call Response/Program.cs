using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Call_Response
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("Write 1 to send message and 2 to receive message");
                int input = int.Parse(Console.ReadLine());

                if (input == 1)
                {
                    TcpClient client = new TcpClient();

                    int port = 42069;
                    IPAddress ip = IPAddress.Parse("172.16.241.194");
                    IPEndPoint endPoint = new IPEndPoint(ip, port);

                    client.Connect(endPoint);

                    NetworkStream stream = client.GetStream();

                    string text = Console.ReadLine();
                    byte[] buffer = Encoding.UTF8.GetBytes(text);

                    stream.Write(buffer, 0, buffer.Length);
                }

                if (input == 2)
                {
                    int port1 = 42069;
                    IPAddress ip1 = IPAddress.Any;
                    IPEndPoint localEndpoint = new IPEndPoint(ip1, port1);
                    TcpListener listener = new TcpListener(localEndpoint);
                    listener.Start();
                    Console.WriteLine("Awaiting Clients");
                    TcpClient client1 = listener.AcceptTcpClient();
                    NetworkStream stream1 = client1.GetStream();
                    byte[] buffer1 = new byte[256];
                    int numberOfBytesRead = stream1.Read(buffer1, 0, 256);
                    string message = Encoding.UTF8.GetString(buffer1, 0, numberOfBytesRead);
                    Console.WriteLine(message);
                }
            } 
        }
    }
}
