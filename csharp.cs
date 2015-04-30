WebRequest req = WebRequest.Create("http://XXX.jitbit.com/helpdesk/api/tickets");
req.Method = "GET";
req.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("admin:admin"));
HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

var arr = JsonConvert.DeserializeObject<JArray>(resp);
foreach (var ticket in arr)
{
    var subject = (string)ticket["Subject"];
}