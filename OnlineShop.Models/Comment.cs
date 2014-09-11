using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        //Navigation Properties

        [Required]
        public string AuthorId { get; set; }
        public virtual ApplicationUser Author { get; set; }

        [Required]
        public int CellPhoneId { get; set; }
        public virtual CellPhone CellPhone { get; set; }
    }
}
