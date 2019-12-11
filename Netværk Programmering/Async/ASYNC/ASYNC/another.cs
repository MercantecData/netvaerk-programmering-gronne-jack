using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ASYNC
{
    class another
    {
        static void Main(string[] args)
        {
            bool isrunning = true;

            int port = 42069;
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);


            TcpListener listener = new TcpListener(localEndpoint);
            Console.WriteLine("Awaiting Clients");
            listener.Start();
            while (isrunning)
            {




                TcpClient client = listener.AcceptTcpClient();

                NetworkStream stream = client.GetStream();

                ReceiveMessage(stream);
                Console.Write("       My message: ");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                stream.Write(buffer, 0, buffer.Length);
                Console.ReadKey();
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
