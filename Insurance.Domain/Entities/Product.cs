namespace Insurance.Domain.Entities
{
    public class Product
    {
        public ProductType Type { get; private set; }
        public float SalesPrice { get; private set; }
        public float InsuranceValue { get; private set; }

        public Product(ProductType type, float salesPrice)
        {
            Type = type;
            SalesPrice = salesPrice;
            InsuranceValue = 0;
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