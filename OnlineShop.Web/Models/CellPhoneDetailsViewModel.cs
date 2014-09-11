using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class CellPhoneDetailsViewModel
    {

        public int Id { get; set; }
       
        public string ManufacturerName { get; set; }
       
        public String Model { get; set; }

       
        public double Display { get; set; }

       
        public int Ram { get; set; }

       
        public int Storage { get; set; }

      
        public string ImageUrl { get; set; }

     
        public decimal Price { get; set; }


        public string AdditionalParts { get; set; }

        public string Description { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}