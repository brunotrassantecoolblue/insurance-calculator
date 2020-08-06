using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Models
{
    public class ProductType
    {
        public int ProductId { get; set; }
        public string ProductTypeName { get; set; }
        public bool ProductTypeHasInsurance { get; set; }
    }
}
