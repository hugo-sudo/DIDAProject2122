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

        private List<string> workersURL; 


        public SchedulerService()
        {
        }

         public override Task<msgResponse> receiveClientRequest(DIDARequest request, ServerCallContext context)
        {

            Console.WriteLine("input recebido:");
            Console.WriteLine(request.Input);

            return Task.FromResult(new msgResponse {Ret = request.Input});

            //preencher o DIDARequest para mandar para o primeiro worker
            //request = createAssignments(request, input, app_file);

            //mandar o request preenchido para o primeiro worker
            //sendToWorker(request);



        }

 
        /*
        ler do script as operacoes
        criar um DIDAAssignment para cada operacao e associar um worker
        retornar um DIDA-Request com a lista de DIDAAssignments
        */
       /* public DIDARequest createAssignments(DIDARequest request,string input,string app_file)
        {
            string[] lines = System.IO.File.ReadAllLines(app_file);

            for (int i = 0; i< workers.Count; i++)
            {
                string operation = lines[i];
                DIDAAssignment assignment = new DIDAAssignment();
                assignment.host = workers[i];
                assignment.port = 2;
                assignment.op =
            }

            return new DIDARequest();
            
        }

        private void sendToWorker(DIDARequest dIDARequest)
        {
            throw new NotImplementedException();
        }
       */






    }



}
