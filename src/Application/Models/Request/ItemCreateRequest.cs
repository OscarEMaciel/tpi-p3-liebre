using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Request
{
    public class ItemCreateRequest
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int StockAvailable { get; set; }
    }
}
