using LibDIDAStorage.Interfaces;
using LibDIDAStorage.Structs;
using System;

namespace DIDAStorage { 

    public class DIDAStorage : IDIDAStorage
    {
        DIDARecord IDIDAStorage.Read(string id, DIDAVersion version)
        {
            throw new NotImplementedException();
        }

        DIDAVersion IDIDAStorage.Write(string id, string val)
        {
            throw new NotImplementedException();
        }

        DIDAVersion IDIDAStorage.UpdateIfValueIs(string id, string oldvalue, string newvalue)
        {
            throw new NotImplementedException();
        }
    }

}
