using System;
using System.Collections.Generic;
using System.Text;

namespace Storage
{
    class StorageService : DIDAStorageService.DIDAStorageServiceBase
    {
        private string server_id;
        public StorageService(string server_id)
        {
            this.server_id = server_id;
        }
    }
}
