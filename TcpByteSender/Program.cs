using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TcpByteSender
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "TcpByteSender";

            Console.Write("Enter The IP>");
            string ip = Console.ReadLine();
            Console.Write(Environment.NewLine + "Enter The Port>");
            string portstring = Console.ReadLine();
            int port = Convert.ToInt32(portstring);


            TcpClient client = new TcpClient(ip, port);

            NetworkStream nwStream = client.GetStream();
            Console.WriteLine("Connected to " + ip + ":" + port.ToString());
            while (true)
            {
                
                Console.Write("HANDLER>");
                string textToSend = Console.ReadLine();
                if (textToSend == "exit")
                {
                    Environment.Exit(0);
                }
                else
                {
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(textToSend);
                    nwStream.Write(bytesToSend, 0, bytesToSend.Length);

                    Console.WriteLine("Text Sended");
                    byte[] bytesToRead = new byte[2048];
                    int bytesRead = nwStream.Read(bytesToRead, 0, 2048);
                    Console.WriteLine("Received : " + Encoding.ASCII.GetString(bytesToRead, 0, 2048));
                    Console.ReadLine();
                    client.Close();
                }
               
            }
           

        }
    }
}
