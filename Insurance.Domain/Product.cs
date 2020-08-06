using System;

namespace Insurance.Domain
{
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public ProductType Type { get; private set; }
        public float SalesPrice { get; private set; }
        public float InsuranceValue { get; private set; }

        public Product(int id, string name, ProductType type, float salesPrice)
        {
            Id = id;
            Name = name;
            Type = type;
            SalesPrice = salesPrice;
            CalculateInsurance();
        }

        private void CalculateInsurance()
        {
            if (Type.IsInsurable == false)
                return;

            if (SalesPrice >= 500 && SalesPrice < 2000)
                InsuranceValue = 1000;
            else if (SalesPrice >= 2000)
                InsuranceValue = 2000;

            if (Type.IsDangerous)
                InsuranceValue += 500;
        }
    }
}