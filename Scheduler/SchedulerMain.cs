﻿using Grpc.Core;
using System;

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
 
            string startupMessage;
            ServerPort serverPort;

            serverPort = new ServerPort(hostname, port, ServerCredentials.Insecure);
            startupMessage = "Insecure ChatServer server listening on port " + port;


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
