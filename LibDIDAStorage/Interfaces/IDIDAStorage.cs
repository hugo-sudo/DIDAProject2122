using LibDIDAStorage.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibDIDAStorage.Interfaces
{
	public interface IDIDAStorage
	{
		DIDARecord Read(string id, DIDAVersion version);
		DIDAVersion Write(string id, string val);
		DIDAVersion UpdateIfValueIs(string id, string oldvalue, string newvalue);
	}
}
