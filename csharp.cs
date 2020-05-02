/* This is a basic example of using Jitbit Helpdesk API with C#
 * We are using a third-party library called JSON.NET. You can get it here (http://json.codeplex.com/)*/

using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JitbitSample
{
	class Program
	{
		static void Main(string[] args)
		{
			//connection settings
			string url = "https://XXX.jitbit.com/helpdesk/api/tickets";
			string username = "username";
			string password = "password";

			WebRequest req = WebRequest.Create(url);
			req.Method = "GET";
			req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
			HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

			using (var reader = new System.IO.StreamReader(resp.GetResponseStream(), UTF8Encoding.UTF8))
			{
				string responseText = reader.ReadToEnd(); //response contains a JSON array of tickets
				var tickets = JsonConvert.DeserializeObject<JArray>(responseText); //Using JSON.NET for deserialization
				foreach (var ticket in tickets)
				{
					Console.WriteLine((string)ticket["Subject"]);
				}
			}
		}
	}
}
