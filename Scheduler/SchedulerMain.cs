using Grpc.Core;
using Grpc.Net.Client;
using System;

namespace Scheduler
{
    class SchedulerMain
    {
        static void Main(string[] args)
        {
            //recebe server_id e URL do puppetMaster
            int port = 1001;
            string url = args[2];

            ServerPort serverPort;
            serverPort = new ServerPort(url, port, ServerCredentials.Insecure);

            Server schedulerServer = new Server
            {
                Services = { },
                Ports = { serverPort }
            };

            schedulerServer.Start();

            //Configuring HTTP for client connections in Register method
            AppContext.SetSwitch(
    "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            while (true) ;

        }
    }
}
