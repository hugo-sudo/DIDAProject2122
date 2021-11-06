using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    class StorageMain
    {
        public static void Main(string[] args)
        {

            //recebe URL do puppetMaster
            string url = args[1];

            //separar hostname de porto
            string[] data = url.Split(':');
            string hostname = data[0];
            int port = int.Parse(data[1]);

            //recebe server_id do puppetMaster
            string server_id = args[0];

            string startupMessage;
            ServerPort serverPort;

            serverPort = new ServerPort(hostname, port, ServerCredentials.Insecure);
            startupMessage = server_id + " storage server node listening on port " + port;


            Server workerServer = new Server
            {
                Services = { DIDAStorageService.BindService(new StorageService(server_id)) },
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
