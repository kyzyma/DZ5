using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Models;

namespace Weather.Services
{
    public interface IGetJasonData
    {
        BaseObject OutData(string city, int days);
    }
}