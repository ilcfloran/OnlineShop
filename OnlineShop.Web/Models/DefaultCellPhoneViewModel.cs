using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    //View Model to show items on landing page
    public class DefaultCellPhoneViewModel
    {
        public int Id { get; set; }

        public String Model { get; set; }

        public String Manufacturer { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }


    }
}