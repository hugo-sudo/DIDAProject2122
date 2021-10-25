using Grpc.Core;
using System;

namespace Scheduler
{
    class SchedulerMain
    {
        public static void Main(string[] args)
        {
            //recebe server_id e URL do puppetMaster
            //int port = 1001;
            //string url = args[2];
            const int port = 1001;
            const string hostname = "localhost";
            string startupMessage;
            ServerPort serverPort;

            serverPort = new ServerPort(hostname, port, ServerCredentials.Insecure);
            startupMessage = "Insecure ChatServer server listening on port " + port;


           // ServerPort serverPort;
            //serverPort = new ServerPort(url, port, ServerCredentials.Insecure);

            Server schedulerServer = new Server
            {
                Services = { DIDASchedulerService.BindService(new SchedulerService()) },
                Ports = { serverPort }
            };

            schedulerServer.Start();

            Console.WriteLine(startupMessage);

            //Configuring HTTP for client connections in Register method
            AppContext.SetSwitch(
       "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            while (true) ;

        }
    }
}
