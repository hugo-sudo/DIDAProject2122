using System;

namespace Structs
{
	public struct DIDAOperatorID
	{
		public string classname;
		public int order;
	}

	public struct DIDAAssignment
	{
		public DIDAOperatorID op;
		public string host;
		public int port;
		public string output;
	}

	public struct DIDARequest
	{
		public DIDAMetaRecord meta;
		public string input;
		public int next;
		public int chainSize;
		public string application_file;
		public DIDAAssignment[] chain;
	}

	public struct DIDAStorageNode
	{
		public string serverId;
		public string host;
		public int port;
	}

	 public struct DIDAMetaRecord
    {
		public int id;
	}



}
