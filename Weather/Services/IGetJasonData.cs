using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Weather.Models;

namespace Weather.Services
{
    public interface IGetJasonData
    {
       Task<BaseObject> OutData(string city, int days);
       Task StatisticCity(string town);
       Task<IEnumerable<string>> GetCities();
       Task AddCity(Town city);
       Task RemoveCity(string city);
    }
}