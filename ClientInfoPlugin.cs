using System;
using System.Collections.Generic;
using System.Text;

namespace DNWS
{
  class ClientInfo : IPlugin
  {
    protected static Dictionary<String, int> clientDictionary = null;
    public ClientInfo()
    {

    }

    public void PreProcessing(HTTPRequest request)
    {

    }
    public HTTPResponse GetResponse(HTTPRequest request)
    {

      //edit     
      String[] getClientInfo = request.getPropertyByKey("RemoteEndPoint").Split(":"); // separate between ip and port
      // request[0,1] ,0 is ip address , 1 is port 
      String clientIP = getClientInfo[0];
      String clientPort = getClientInfo[1];
      //end of edit  

      HTTPResponse response = null;
      StringBuilder sb = new StringBuilder();


      //edit 
        sb.Append("<html><body>");
        sb.Append("<h2><u>Client Infomation</u></h2>");
        sb.Append("Client IP Address: " + clientIP + "<br>");
        sb.Append("Client Port: " + clientPort + "<br>");
        sb.Append("Browser Information: " + request.getPropertyByKey("user-agent") + "<br>");
        sb.Append("Accept Language: " + request.getPropertyByKey("accept-language") + "<br>");
        sb.Append("Accept Encoding: " + request.getPropertyByKey("accept-encoding") + "<br>");
        sb.Append("</body></html>");
      // end of edit

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