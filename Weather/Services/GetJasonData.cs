using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Weather.Models;

namespace Weather.Services
{
    public class GetJasonData: IGetJasonData
    {
        public BaseObject OutData(string city, int days)
        {
            string request = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&units=metric&APPID=802bb162764fbde7568d9b8ea4e4b2ee";

            using (WebClient wc = new WebClient())
            {
                var json = wc.DownloadString(request);     // "http://api.openweathermap.org/data/2.5/forecast/daily?q=lviv&units=metric&APPID=802bb162764fbde7568d9b8ea4e4b2ee"

                // string jsonStr = "{\"city\":{\"id\":702550,\"name\":\"Lviv\",\"coord\":{\"lon\":24.023239,\"lat\":49.838261},\"country\":\"UA\",\"population\":0},
                //  \"cod\":\"200\",
                //  \"message\":0.0333,
                //  \"cnt\":7,
                //  \"list\":[{\ "dt\":1467885600,
                //\"temp\":{\"day\":14.84,\"min\":14,\"max\":18.59,\"night\":14.31,\"eve\":18.59,\"morn\":14},
                //\"pressure\":1002.61, -тиск
                //\"humidity\":85,      -вологість
                //\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],
                //\"speed\":9.76,   -швидкість вітру
                //\"deg\":290,      -кут вітру
                //\"clouds\":92,    -хмарність %
                //\"rain\":1.14},
                //{\"dt\":1467972000,\"temp\":{\"day\":19.52,\"min\":9.95,\"max\":21.58,\"night\":16.85,\"eve\":21.58,\"morn\":9.95},\"pressure\":1007.61,\"humidity\":73,
                //\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"speed\":4.66,\"deg\":277,\"clouds\":12},
                //{\"dt\":1468058400,\"temp\":{\"day\":17.56,\"min\":14.11,\"max\":17.76,\"night\":14.11,\"eve\":17.11,\"morn\":16.41},\"pressure\":999.18,\"humidity\":96,
                //\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"speed\":6.64,\"deg\":289,\"clouds\":68,\"rain\":7.03},
                //{\"dt\":1468144800,\"temp\":{\"day\":21.17,\"min\":11.57,\"max\":23.39,\"night\":18.07,\"eve\":23.39,\"morn\":11.57},\"pressure\":1005,\"humidity\":86,
                //\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"speed\":3.27,\"deg\":275,\"clouds\":12},
                //{\"dt\":1468231200,\"temp\":{\"day\":28.39,\"min\":20.52,\"max\":28.39,\"night\":20.52,\"eve\":26.3,\"morn\":23.13},\"pressure\":995.5,\"humidity\":0,
                //\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"speed\":5.06,\"deg\":284,\"clouds\":8},
                //{\"dt\":1468317600,\"temp\":{\"day\":33.15,\"min\":22.71,\"max\":33.15,\"night\":22.71,\"eve\":29.96,\"morn\":27.04},\"pressure\":994.43,\"humidity\":0,
                //\"weather\":[{\"id\":800,\"main\":\"Clear\",\"description\":\"clear sky\",\"icon\":\"01d\"}],\"speed\":6.39,\"deg\":236,\"clouds\":0},
                //{\"dt\":1468404000,\"temp\":{\"day\":34.5,\"min\":22.68,\"max\":34.5,\"night\":22.68,\"eve\":29.24,\"morn\":28.59},\"pressure\":992.54,\"humidity\":0,
                //\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"speed\":5.19,\"deg\":262,\"clouds\":0,\"rain\":0.8}]}";

                BaseObject outObject = JsonConvert.DeserializeObject<BaseObject>(json); //jsonStr
                outObject.CountDays = days;
                return outObject;

            }
        }
    }
}