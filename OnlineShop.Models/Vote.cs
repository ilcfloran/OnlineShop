using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Vote
    {
        [Key]
        public int Id { get; set; }

      
        //Navigation Properties

        [Required]
        public string VotedById { get; set; }
        [ForeignKey("VotedById")]
        public virtual ApplicationUser VotedBy { get; set; }

        [Required]
        public int CellPhoneId { get; set; }
        public virtual CellPhone CellPhone { get; set; }
    }
}
