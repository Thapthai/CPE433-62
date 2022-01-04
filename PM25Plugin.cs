using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text.Json;
using System.Runtime.Serialization.Json;
using System.Net;
using System.IO;

namespace DNWS
{
    class PM25Plugin : IPlugin
    {
        private static readonly HttpClient client = new HttpClient();
        protected static PM25Reading pm25reading = null;

        public PM25Plugin()
        {
            if (pm25reading == null) {
                RequestAqiCn();
            }
        }

        public void RequestAqiCn()
        {
            HttpWebRequest http = (HttpWebRequest) WebRequest.Create("http://api.waqi.info/feed/shanghai/?token=demo");
            HttpWebResponse response = (HttpWebResponse) http.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string content = sr.ReadToEnd();
            pm25reading = JsonSerializer.Deserialize<PM25Reading>(content);
        }
        
        public void PreProcessing(HTTPRequest request)
        {
            throw new NotImplementedException();
        }

        public HTTPResponse GetResponse(HTTPRequest request)
        {
            if (pm25reading == null) {
                RequestAqiCn();
            } else {
                DateTime now = DateTime.Now;
                TimeSpan diff = now.Subtract(pm25reading.data.time.iso.DateTime);
                if (diff >= new TimeSpan(1, 0, 0)) {
                    RequestAqiCn();
                }
            }

            HTTPResponse response = null;
            StringBuilder sb = new StringBuilder();
            sb.Append("<html><body>");
            sb.Append("Location : " + pm25reading.data.city.name + "<br />");
            sb.Append("Date/Time : " + pm25reading.data.time.iso + "<br />");
            sb.Append("PM25 : " + pm25reading.data.iaqi.pm25.v + "<br />");
            sb.Append("PM10 : " + pm25reading.data.iaqi.pm10.v + "<br />");
            sb.Append("</body></html>");
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
