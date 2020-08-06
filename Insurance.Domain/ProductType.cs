﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Insurance.Domain
{
    public class ProductType
    {
        public static readonly string[] DangerousTypesNames = { "Laptops", "Smartphones" };
        public string Name { get; private set; }
        public bool IsInsurable { get; private set; }
        public bool IsDangerous { get; internal set; }
        public ProductType(string name, bool isInsurable)
        {
            Name = name;
            IsInsurable = isInsurable;
            IsDangerous = DangerousTypesNames.Contains(name);
        }
    }
}