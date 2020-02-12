using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Services
{
    public class SocketService
    {
        [Obsolete]
        public static void RunSocketServer()
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
            Console.WriteLine(" >> exit");
            Console.ReadLine();
        }
    }
}
