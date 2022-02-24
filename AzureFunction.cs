using System.Net;  
using System.Configuration;  
  
public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)  
{  
    log.Info($"C# HTTP trigger function processed a request. RequestUri={req.RequestUri}");  
  
      
    return req.CreateResponse(HttpStatusCode.Ok, "hola mundo");
}  