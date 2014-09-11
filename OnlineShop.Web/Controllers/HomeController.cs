using OnlineShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Web.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            if (this.HttpContext.Cache["ListOfPhones"] == null)
            {
                var ListOfCellPhones = this.Data.CellPhones.All()
                .OrderByDescending(x => x.Vote.Count())
                .Take(6)
                 .Select(x => new DefaultCellPhoneViewModel
           {
               Id = x.Id,
               Manufacturer = x.Manufacturer.Name,
               ImageUrl = x.ImageUrl,
               Model = x.Model,
               Price = x.Price
           });
           
                this.HttpContext.Cache.Add("ListOfPhones", ListOfCellPhones.ToList(), null, DateTime.Now.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);

            }

            

          return View(this.HttpContext.Cache["ListOfPhones"]);
        }

    }
}