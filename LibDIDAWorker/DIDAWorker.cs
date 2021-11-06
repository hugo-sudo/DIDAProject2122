using Structs;
using System;

namespace DIDAWorker {

	public class WorkerService : DIDAWorkerService.DIDAWorkerServiceBase
	{

		public WorkerService()
        {
        }
	
	}

	public enum OperationType { ReadOp, WriteOp, UpdateIfOp };

	public delegate DIDAStorageNode delLocateStorageId(string id, OperationType type);




}
