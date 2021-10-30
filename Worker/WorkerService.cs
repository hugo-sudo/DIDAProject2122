using Grpc.Core;
using System;
using System.Threading.Tasks;

namespace Worker
{

	public class WorkerService : DIDAWorkerService.DIDAWorkerServiceBase
	{

		public WorkerService()
		{ 
		}

		//TO-DO
        /*public override Task<msgResponse> receiveRequest(DIDARequest request, ServerCallContext context) {
			
		}*/

	}

	//public enum OperationType { ReadOp, WriteOp, UpdateIfOp };

	//public delegate DIDAStorageNode delLocateStorageId(string id, OperationType type);




}
