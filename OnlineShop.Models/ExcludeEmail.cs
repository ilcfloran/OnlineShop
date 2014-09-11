using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ExcludeEmail : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string valueAsSString = value as string;
            if (valueAsSString == null)
            {
                return false;
            }
            

            if(Regex.IsMatch(valueAsSString, @"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,4}"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
