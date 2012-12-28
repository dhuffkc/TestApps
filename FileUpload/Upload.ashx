<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;

public class Upload : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.AddHeader("Cache-control", "no-cache");
        context.Response.ContentType = "application/json";
        context.Response.Write("{ \"message\": \"Hello World\" }");
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}