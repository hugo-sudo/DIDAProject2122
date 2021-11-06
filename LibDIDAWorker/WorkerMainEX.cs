using DIDAWorker;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibDIDAWorker
{
    class WorkerMainEX
    {
        public static void Main(string[] args)
        {

            /*  //recebe URL do puppetMaster
              string url = args[0];

              //separar hostname de porto
              string[] data = url.Split(':');
              string hostname = data[0];
              int port = int.Parse(data[1]);*/
            const int port = 1001;
            const string hostname = "localhost";

            string startupMessage;
            ServerPort serverPort;

            serverPort = new ServerPort(hostname, port, ServerCredentials.Insecure);
            startupMessage = "Insecure ChatServer server listening on port " + port;


            Server workerServer = new Server
            {
                Services = { DIDAWorkerService.BindService(new WorkerService()) },
                Ports = { serverPort }
            };

            workerServer.Start();

            Console.WriteLine(startupMessage);

            //Configuring HTTP for client connections in Register method
            AppContext.SetSwitch(
            "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            while (true) ;

        }
    }
}
