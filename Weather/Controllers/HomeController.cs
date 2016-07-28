using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Weather.Models;
using Weather.Services;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {        
        IGetJasonData _dataServise;
       
        public HomeController(IGetJasonData dataServise)
        {
            _dataServise = dataServise;          
        }

        // GET: /Home/

        public async Task<ActionResult> Index()
        {            
            this.ViewBag.Cities = new SelectList(await _dataServise.GetCities());
            return View(await _dataServise.OutData("london", 3));
        }

        [HttpPost]
        public async Task<ActionResult> Index(BaseObject baseOb)
        {
            if (baseOb.ChooseCityInput == null || baseOb.ChooseCityInput.Length == 0)
            {
                await _dataServise.StatisticCity(baseOb.ChooseCityList);

                this.ViewBag.Cities = new SelectList(await _dataServise.GetCities());               

                return View(await _dataServise.OutData(baseOb.ChooseCityList, baseOb.CountDays));
            }
            else
            {
                await _dataServise.StatisticCity(baseOb.ChooseCityInput);

                this.ViewBag.Cities = new SelectList(await _dataServise.GetCities());

                return View(await _dataServise.OutData(baseOb.ChooseCityInput, baseOb.CountDays));
            }
        }       

        public ActionResult Setting()
        {            
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Setting(string addCity, string delCity)
        {
            if (addCity.Length != 0)
            {
                await _dataServise.AddCity(new Town { name = addCity });
                ViewBag.Add = "*City successfully added to list " ;
            }

            if (delCity.Length != 0)
            {
                await _dataServise.RemoveCity(delCity);
                ViewBag.Removed += "*City successfully removed from list";               
            }
            return View();
        }

        public ActionResult Statistic()
        {
            return View(new ContextCity());
        }
    }
}
