using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Models;
using Weather.Services;

namespace Weather.Controllers
{
    public class HomeController : Controller
    {        
        IGetJasonData _jsData;
        ContextCity context = new ContextCity();

        public HomeController(IGetJasonData jsData)
        {
            _jsData = jsData;          
        }

        // GET: /Home/

        public ActionResult Index()
            {
                var ob = _jsData.OutData("london",3);
                ob.listTown = context.Towns.ToList();   //list city from BD
                return View(ob);
            }

        [HttpPost]
        public ActionResult Index(BaseObject baseOb)
        {
            if (baseOb.ChooseCityInput == null || baseOb.ChooseCityInput.Length == 0)
            {
                StatisticCity(baseOb.ChooseCityList);
                var ob = _jsData.OutData(baseOb.ChooseCityList, baseOb.CountDays);
                ob.listTown = context.Towns.ToList();
                return View(ob);
            }
            else
            {
                StatisticCity(baseOb.ChooseCityInput);
                var ob = _jsData.OutData(baseOb.ChooseCityInput, baseOb.CountDays);
                ob.CountDays = baseOb.CountDays;
                ob.listTown = context.Towns.ToList();
                return View(ob);
            }
        }

        void StatisticCity(string town)
        {            
            var isCity = context.Statistics.FirstOrDefault(s => s.city == town);
            if(isCity != null)
            {
                 ++isCity.count;
                context.SaveChanges();
            }
            else
            {
                context.Statistics.Add(new Statistic { city = town, count = 1 });
                context.SaveChanges();
            }
        }

        public ActionResult Setting()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Setting(string addCity, string delCity)
        {
            if (addCity.Length != 0)
            {
                context.Towns.Add(new Town { name = addCity });
                context.SaveChanges();
                ViewBag.Add = "*City successfully added to list " ;
            }

            if (delCity.Length != 0)
            {
                Town delItem = context.Towns.Where(i => i.name == delCity).FirstOrDefault();

                if (delItem != null)
                {
                    context.Towns.Remove(delItem);
                    context.SaveChanges();
                    ViewBag.Removed += "*City successfully removed from list";
                }
                else
                    ViewBag.Removed += "*" + delCity + " does not exist in the list";
            }
            return View();
        }

        public ActionResult Statistic()
        {
            return View(context);
        }




    }
}
