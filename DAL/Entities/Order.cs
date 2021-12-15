using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
