using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class CellPhone
    {
        private ICollection<Comment> comments;
        private ICollection<Vote> votes;

        public CellPhone()
        {
            this.comments = new HashSet<Comment>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }
        
        //Device Spec
        [Required]
        public String Model { get; set; }

        [Required]
        public double Display { get; set; }

        [Required]
        public int Ram { get; set; }

        [Required]
        public int Storage { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        
        public string AdditionalParts { get; set; }

        public string Description { get; set; }



        //Navigation Properties
        [Required]
        public int ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        public int CommentId { get; set; }
        public virtual ICollection<Comment> Comment 
        {
            get { return this.comments;}
            set { this.comments = value;} 
        }

        public int VoteId { get; set; }
        public virtual ICollection<Vote> Vote
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

    }
}
