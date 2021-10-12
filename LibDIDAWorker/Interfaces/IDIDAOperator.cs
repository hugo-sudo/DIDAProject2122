using System;
using System.Collections.Generic;
using System.Text;
using DIDAWorker;
using LibDIDAWorker.Structs;

namespace LibDIDAWorker.Interfaces
{
    interface IDIDAOperator
    {
        public string ProcessRecord(DIDAMetaRecord meta, string input);
        public void ConfigureStorage(DIDAStorageNode[] storageReplicas, delLocateStorageId locationFunction);
        // the location function is passed to the operator so it may know in which storage node to do an operation
        // based on the record id and the operation type.
    }
}
