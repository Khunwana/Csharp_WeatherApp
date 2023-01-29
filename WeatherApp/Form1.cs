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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string ApiKey = "c37457da5dfefe167e543ee3a030c27a";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            getWeather();
            weather_forecast();
        }

        void getWeather()
        {
             using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}",TBCity.Text,ApiKey);
                var json = web.DownloadString(url);
                WeatherAPiInfo.root Info = JsonConvert.DeserializeObject<WeatherAPiInfo.root>(json);

                //fetching the image icon
                picIcon.ImageLocation = string.Format("https://api.openweathermap.org/img/w/{0}.png",Info.weather[0].icon);

                //fetching the condition
                labTempararue.Text = KelvinValueCOnversion(Info.main.temp).ToString();

                //fetching the details
                labDetails.Text = Info.weather[0].description;

                //fetching the sunrise 
                labSunrise.Text = convertDateTime(Info.sys.sunrise).ToString();

                //fetching the sunset
                labSunset.Text = convertDateTime(Info.sys.sunset).ToString();

                //fetching the wind speed
                labWindSpeed.Text = Info.wind.speed.ToString();

                //fetching the pressure
                labPressure.Text = Info.main.pressure.ToString();

                //fetching the date
                labDate.Text = convertDateTime(Info.dt).ToString();

                string lat_coord = Info.coord.lat.ToString();
                string lon_coord = Info.coord.lon.ToString();

            }
        }

        void weather_forecast()
        {
            using(WebClient forecast_client = new WebClient())
            {
                //This url is for fetching the weather forecast for the count 3 (cnt=3)
                string forecast_url = string.Format("https://api.openweathermap.org/data/2.5/forecast?q={0}&cnt=3&appid={1}", TBCity.Text, ApiKey);
                var forecast_json = forecast_client.DownloadString(forecast_url);
                forecast.root forecast_info = JsonConvert.DeserializeObject<forecast.root>(forecast_json);

                labDate_for1.Text = convertDateTime(forecast_info.list[0].dt).ToString();
                labDate_for2.Text = convertDateTime(forecast_info.list[1].dt).ToString();
                labDate_for3.Text = convertDateTime(forecast_info.list[2].dt).ToString();

                labConD1.Text = forecast_info.list[0].weather[0].main.ToString();
                labConD2.Text = forecast_info.list[1].weather[0].main.ToString();
                labConD3.Text = forecast_info.list[2].weather[0].main.ToString();

                labTempD1.Text = KelvinValueCOnversion(forecast_info.list[0].main.temp).ToString();
                labTempD2.Text = KelvinValueCOnversion(forecast_info.list[1].main.temp).ToString();
                labTempD3.Text = KelvinValueCOnversion(forecast_info.list[2].main.temp).ToString();
                ///picIcon.ImageLocation = string.Format("https://api.openweathermap.org/img/w/{0}.png",Info.weather[0].icon);

                picIcon_for1.ImageLocation = string.Format("https://api.openweathermap.org/img/w/{0}.png", forecast_info.list[0].weather[0].icon);
                picIcon_for2.ImageLocation = string.Format("https://api.openweathermap.org/img/w/{0}.png", forecast_info.list[1].weather[0].icon);
                picIcon_for3.ImageLocation = string.Format("https://api.openweathermap.org/img/w/{0}.png", forecast_info.list[2].weather[0].icon);



            }
        }

        DateTime convertDateTime(long seconds)
        {
            DateTime day = new DateTime(1970, 1, 1, 0, 0, 0, 0,System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(seconds).ToLocalTime();
            return day;
        }

        double KelvinValueCOnversion(double kel)
        {
            double kelvinValue =kel - 273.15;
            return kelvinValue;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
