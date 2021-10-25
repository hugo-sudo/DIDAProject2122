using Grpc.Core;
using Grpc.Net.Client;
using Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Scheduler
{
    class SchedulerService : DIDASchedulerService.DIDASchedulerServiceBase   {

        // canal pelo qual os clientes vao comunicar com o scheduler
        private GrpcChannel channel;

        public SchedulerService()
        {

        }

        public void receiveClientRequest(DIDARequest request)
        {
            string input = request.input;
            string app_file = request.application_file;
            
        }

        public void sendToWorker()
        {
            DIDAMetaRecord meta_rec;
            
        }

        private DIDARequest request1;









    }
    
        
    
}
