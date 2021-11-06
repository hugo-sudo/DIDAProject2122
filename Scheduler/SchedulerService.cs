using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scheduler
{
    class SchedulerService : DIDASchedulerService.DIDASchedulerServiceBase   {

        private string server_id;
        private Dictionary<string, string> workersServers;



        public SchedulerService(string server_id,Dictionary<string,string> workersServers)
        {
            this.server_id = server_id;
            this.workersServers = workersServers;

        }

         public override Task<msgResponse> receiveClientRequest(RecvDIDARequest request, ServerCallContext context)
        {
            
            // adiciona o array de DIDAAssignemnt e o seu tamanho
            request = createAssignments(request.);

            //cria DIDAMetaRecord
            request.Meta = new DIDAMetaRecord { Id = 0 };

            //adiciona next
            request.Next = 0;


            return Task.FromResult(new msgResponse {Ret = request.Input});

           

            //mandar o request preenchido para o primeiro worker
            //sendToWorker(request);



        }

         


        /*
        ler do script as operacoes
        criar um DIDAAssignment para cada operacao e associar um worker
        retornar um DIDA-Request com a lista de DIDAAssignments
        */
        public BcastDIDARequest createAssignments(BcastDIDARequest request)
         {

            string[] lines = System.IO.File.ReadAllLines(request.ApplicationFile);
            int i = 0;

            foreach(string line in lines )
            {
                string[] getOP = line.Split(" ");
                string[] aux =  workersServers.ElementAt(i).Value.Split(":");
                request.Chain.Add(new DIDAAssignment
                {
                    Host = aux[0],
                    Output = "",
                    Port = Int32.Parse(aux[1]),
                    Operator = new DIDAOperator { Classname = getOP[0], SeqNo = Int32.Parse(getOP[2]) }
                });
                i++;
                
            }

            request.ChainSize = request.Chain.Count;

            return request;

            

         }

         private void sendRequestToWorker(DIDARequest dIDARequest)
         {
            // setup the client side
            AppContext.SetSwitch(
                "System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            GrpcChannel channel = GrpcChannel.ForAddress("ola");

            var client = new DIDASchedulerClientService.DIDASchedulerClientServiceClient(channel);

            client.requestToWorker(new DIDARequest { Input = textBox4.Text, ApplicationFile = textBox3.Text });
        }
        






    }



}
