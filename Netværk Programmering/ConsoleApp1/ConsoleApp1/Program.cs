using System;
using System.Text;
namespace Netværk_Programmering
{
    class Program1
    {
        static void Main(string[] args)
        {

            string text1 = "ÆØÅLOLMAOÆØÅ";
            var bytes1 = Encoding.ASCII.GetBytes(text1);

            Console.WriteLine("Done!");

            text1 = Encoding.ASCII.GetString(bytes1);

            string text2 = "Hello World! ÆØÅ ÆØÅ LÆØÅ YE";
            var bytes = Encoding.UTF8.GetBytes(text2);

            Console.WriteLine("Done!");

            text2 = Encoding.UTF8.GetString(bytes);

            Console.WriteLine(text2);

            int i = 0;

        }
    }
}
