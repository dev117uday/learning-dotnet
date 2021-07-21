using System;
using System.Collections.Generic;
using System.Net;
using RestSharp;
using Newtonsoft.Json;

namespace ScriptCli
{
	class RestSharp
	{
		static void Resquest(string[] args)
		{
			var client = new RestClient("");
			client.Timeout = -1;
			var request = new RestRequest(Method.GET);
			IRestResponse response = client.Execute(request);
            Console.WriteLine(response.StatusCode);
            Dictionary<string, string> newDict = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            if (newDict != null) Console.WriteLine(newDict["sub"]);
		}
	}
}
