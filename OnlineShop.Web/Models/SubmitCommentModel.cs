using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Web.Models
{
    public class SubmitCommentModel
    {

        [Required]
        [ExcludeEmail]
        public string Comment { get; set; }

        [Required]
        public int CellPhoneId { get; set; }
    }
}