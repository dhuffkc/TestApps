<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;

public class Upload : IHttpHandler {
	
	public void ProcessRequest (HttpContext context) {
		context.Response.AddHeader("Cache-control", "no-cache");
		context.Response.ContentType = "text/plain";	// required by IE 8 to correctly parse JSON result from IFRAME
		context.Response.Write("{ \"message\": \"Hello World at " + DateTime.Now.ToLongTimeString() + "\" }");
	}
 
	public bool IsReusable {
		get {
			return false;
		}
	}

}