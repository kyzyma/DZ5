using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using Weather.Models;
using System.Data.Entity;

namespace Weather.Services
{
    public class GetJasonData: IGetJasonData
    {
        ContextCity context = new ContextCity();

        public async Task<BaseObject> OutData(string city, int days)
        {
            BaseObject outObject;
            string json = "";           
            string request = "http://api.openweathermap.org/data/2.5/forecast/daily?q=" + city + "&units=metric&APPID=802bb162764fbde7568d9b8ea4e4b2ee";
                                                                                                                     
            using (WebClient wc = new WebClient())
            {
                json = await wc.DownloadStringTaskAsync(request);                
            }
   
           /*  //alternative variant
            HttpClient httpClient = new HttpClient();
            var httpResponse = await httpClient.GetAsync(request);
            json = await httpResponse.Content.ReadAsStringAsync();
           */  

            outObject = JsonConvert.DeserializeObject<BaseObject>(json); 
            outObject.CountDays = days;

            return outObject;            
        }

        public async Task StatisticCity(string town)
        {            
            var isCity = await context.Statistics.FirstOrDefaultAsync(s => s.city == town);  // if City exist in DB
            if (isCity != null)
            {
                ++isCity.count;
                await context.SaveChangesAsync();
            }
            else
            {
                context.Statistics.Add(new Statistic { city = town, count = 1 });
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<string>> GetCities()         
        {            
            return await context.Towns.Select(c => c.name).ToListAsync();
        }

        public async Task AddCity(Town city)
        {
            context.Towns.Add(city);
            await context.SaveChangesAsync();
        }

        public async Task RemoveCity(string delCity)
        {
            var delItem = await context.Towns.Where(i => i.name == delCity).FirstOrDefaultAsync();
            context.Towns.Remove(delItem);
            await context.SaveChangesAsync();
        }
    }
}