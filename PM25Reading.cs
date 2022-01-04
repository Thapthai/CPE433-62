using System;
namespace DNWS
{
    class PM25ipm10
    {
        public int v {get; set;}
    }
    class PM25ipm25
    {
        public int v {get; set;}
    }
    class PM25iaqi 
    {
        public PM25ipm10 pm10 {get; set;}
        public PM25ipm25 pm25 {get; set;}
    }
    class PM25city
    {
        public string name {get; set;}
    }
    class PM25time
    {
        public DateTimeOffset iso {get; set;}
    }
    class PM25data
    {
        public int aqi {get; set;}
        public PM25city city {get; set;}
        public string dominentpol {get; set;}
        public PM25iaqi iaqi {get; set;}
        public PM25time time {get; set;}
    }
    class PM25Reading
    {
        public string status {get; set; }
        public PM25data aqi {get; set;}
        public PM25data data { get; set;}

    }

}