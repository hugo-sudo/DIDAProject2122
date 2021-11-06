using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Worker
{

	public class WorkerService : DIDAWorkerService.DIDAWorkerServiceBase
	{

		private string server_id;

		public WorkerService(string server_id)
		{
			this.server_id = server_id;
			Console.WriteLine(this.server_id);
		}

		//TO-DO
        /*public override Task<msgResponse> receiveRequest(DIDARequest request, ServerCallContext context) {
			
		}*/

	}

	//public enum OperationType { ReadOp, WriteOp, UpdateIfOp };

	//public delegate DIDAStorageNode delLocateStorageId(string id, OperationType type);




}
