using Insurance.Domain.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Insurance.Infrastructure
{
    public class ProductAPIClient
    {
        public string BaseAddress { get; private set; }
        private readonly string productTypesResource = "/product_types";
        private readonly string productsResource = "/products";


        public async Task<ProductType> GetProductType(int productTypeId)
        {
            //cash types?
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
            {
                var httpResponse = await client.GetAsync($"{productTypesResource}/{productTypeId}");

                if (httpResponse.IsSuccessStatusCode == false)
                    throw new DependencyApiException(productTypesResource, productTypeId);

                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                var productType = JsonConvert.DeserializeObject<ProductType>(jsonString);

                return productType;
            }
        }

        public async Task<Product> GetProduct(int productId)
        {
            //cash types?
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
            {
                var httpResponse = await client.GetAsync($"{productsResource}/{productId}");

                if (httpResponse.IsSuccessStatusCode == false)
                    throw new DependencyApiException(productsResource, productId);

                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(jsonString);

                return product;
            }
        }
    }
}
