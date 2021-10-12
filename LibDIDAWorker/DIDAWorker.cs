using LibDIDAWorker.Structs;
using System;

namespace DIDAWorker {

	public enum OperationType { ReadOp, WriteOp, UpdateIfOp};

	public delegate DIDAStorageNode delLocateStorageId(string id, OperationType type);

}
