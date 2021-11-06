using Grpc.Core;
using System;
using System.Collections.Generic;

namespace Scheduler
{
    class SchedulerMain
    {
        public static void Main(string[] args)
        {


            //recebe URL do puppetMaster
            string url = args[0];

            //separar hostname de porto
            string[] data = url.Split(':');
            string hostname = data[0];
            int port = int.Parse(data[1]);

            //recebe server_id do puppetMaster
            string server_id = args[1];

            //recebe as locations dos workers
            Dictionary<string, string> workers_servers = new Dictionary<string, string>();
            int i = 2;
            string cur_arg = args[i];
            while(i < args.Length)
            {
                cur_arg = args[i];
                Console.WriteLine(cur_arg);
                string[] worker_info = cur_arg.Split("|");
                workers_servers.Add(worker_info[0], worker_info[1]);
                i++;
            }


            string startupMessage;
            ServerPort serverPort;

            serverPort = new ServerPort(hostname, port, ServerCredentials.Insecure);
            startupMessage = "Insecure ChatServer server listening on port " + port;


            Server schedulerServer = new Server
            {
                Services = { DIDASchedulerService.BindService(new SchedulerService(server_id, workers_servers)) },
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
