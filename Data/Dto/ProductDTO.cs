using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Dto
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public double Price { get; set; }
    }
}
