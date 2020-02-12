using System;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            TcpListener serverSocket = new TcpListener(42000);
            int requestCount = 0;
            TcpClient clientSocket = default;
            serverSocket.Start();
            Console.WriteLine(" >> Server Started");
            clientSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine(" >> Accept connection from client");
            requestCount = 0;


            while ((true))
            {
                try
                {
                    requestCount = requestCount + 1;
                    var networkStream = clientSocket.GetStream();
                    var bytesFrom = new byte[clientSocket.ReceiveBufferSize];
                    networkStream.Read(bytesFrom, 0, clientSocket.ReceiveBufferSize);
                    string dataFromClient = Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine(">>  " + dataFromClient + "\n");
                    //WtiteToFile(">>  " + dataFromClient + "\n");
                    //ReadFromFile();


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            clientSocket.Close();
            serverSocket.Stop();
            //Console.WriteLine(" >> exit");
            //Console.ReadLine();
        }
    }
}
