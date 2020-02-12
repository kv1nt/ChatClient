using ChatClient.Context;
using ChatClient.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Extentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("mssqlconnection");
            services.AddDbContext<ChatContext>(o => o.UseSqlServer(connectionString));
        }

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        [Obsolete]
        public static void CreateSocketServer(this IServiceCollection services)
        {
            TcpListener serverSocket = new TcpListener(42000);
            int requestCount = 0;
            TcpClient clientSocket = default;
            serverSocket.Start();
            //Console.WriteLine(" >> Server Started");
            clientSocket = serverSocket.AcceptTcpClient();
            //Console.WriteLine(" >> Accept connection from client");
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
            //Console.WriteLine(" >> exit");
            //Console.ReadLine();
        }
    }
}

