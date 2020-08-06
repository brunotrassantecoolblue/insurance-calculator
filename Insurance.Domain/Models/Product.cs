using System;
using System.Collections.Generic;
using System.Text;

namespace Insurance.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductType { get; set; }
        public float SalesPrice { get; set; }
    }
}
