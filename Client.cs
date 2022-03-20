using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientPlugin : IPlugin
  {

    public void PreProcessing(HTTPRequest request)
    {
      throw new NotImplementedException();  
    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {
      String[] client = request.getPropertyByKey("RemoteEndPoint").Split(":");
      String broswer_info = request.getPropertyByKey("User-Agent");
      String accept_language = request.getPropertyByKey("Accept-Language");
      String accept_encoding = request.getPropertyByKey("Accept-Encoding");

      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();
      sb.Append("<html><body><pre>");
      sb.Append("Client IP: " +client[0] +"<br><br>");
      sb.Append("Client Port: " +client[1] +"<br><br>");
      sb.Append("Browser Information: " +broswer_info +"<br>");
      sb.Append("Accept Language: " +accept_language +"<br>");
      sb.Append("Accept Encoding: " +accept_encoding +"<br>");
      sb.Append("</pre></body></html>");
      response = new HTTPResponse(200);
      response.body = Encoding.UTF8.GetBytes(sb.ToString());
      return response;
    }

    public HTTPResponse PostProcessing(HTTPResponse response)
    {
      throw new NotImplementedException();
    }
  }
} 