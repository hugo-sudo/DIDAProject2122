using System;
using System.Collections.Generic;
using System.Text;

namespace LibDIDAWorker.Structs
{
	public struct DIDARequest
	{
		public DIDAMetaRecord meta;
		public string input;
		public int next;
		public int chainSize;
		public DIDAAssignment[] chain;
	}
}
