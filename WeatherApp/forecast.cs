using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;



namespace WeatherApp
{
    class forecast
    {
        public class root
        {
            public long cod { get; set; }
            public long message { get; set; }
            public long cnt { get; set; }
            public city city { get; set; }
            public List<list> list { get; set; }
        }
        public class list
        {
            public long dt { get; set; }
            public main main { get; set; }
            public List<weather> weather { get; set; }
            public clouds clouds { get; set; }
            public wind wind { get; set; }
            public long visibility { get; set; }
            public long pop { get; set; }
            public sys sys { get; set; }
            public string dt_txt { get; set; }
        }
        public class sys
        {
            public string pod { get; set; }
        }
        public class wind
        {
            public double speed { get; set; }
            public long deg { get; set; }
            public double gust { get; set; }

        }
        public class clouds
        {
            public long all { get; set; }
        }
        public class city
        {
            public long id { get; set; }
            public string name { get; set; }
            public string country { get; set; }
            public long populatuon { get; set; }
            public long timezone { get; set; }
            public long sunrise { get; set; }
            public long sunset { get; set; }
            public coords coords { get; set; }
        }
        public class coords
        {
            public double lat { get; set; }
            public double lon { get; set; }
        }
        public class main
        {
            public double temp { get; set; }
            public double feels_like { get; set; }
            public double temp_min { get; set; }
            public double temp_max { get; set; }
            public long pressure { get; set; }
            public long sea_level { get; set; }
            public long grnd_level { get; set; }
            public long humidity { get; set; }
            public double temp_kf { get; set; }
        }
        public class weather
        {
            public long id { get; set; }
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }

        }
    }
}
