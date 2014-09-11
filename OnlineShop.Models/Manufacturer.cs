using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Manufacturer
    {

        private ICollection<CellPhone> cellPhones;
        public Manufacturer ()
        {
            this.cellPhones = new HashSet<CellPhone>();
        }

        public int Id { get; set; }

        [Required]
        public String Name { get; set; }


        //Nav Properties
        public virtual ICollection<CellPhone> CellPhones
        {
            get { return this.cellPhones; }
            set { this.cellPhones = value; }
        }

    }
}
