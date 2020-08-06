using Insurance.Domain.Models;
using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Insurance.Domain.Repositories;

namespace Insurance.Infrastructure
{
    public class ProductAPIClient : IProductRepository
    {
        public string BaseAddress { get; private set; }
        private readonly string productTypesResource = "/product_types";
        private readonly string productsResource = "/products";


        public async Task<ProductTypeModel> GetProductType(int productTypeId)
        {
            //cash types?
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
            {
                var httpResponse = await client.GetAsync($"{productTypesResource}/{productTypeId}");

                if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    return null;
                else if (httpResponse.IsSuccessStatusCode == false)
                    throw new DependencyApiException(productTypesResource, productTypeId);

                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                var productType = JsonConvert.DeserializeObject<ProductTypeModel>(jsonString);

                return productType;
            }
        }

        public async Task<ProductModel> GetProduct(int productId)
        {
            //cash types?
            using (HttpClient client = new HttpClient { BaseAddress = new Uri(BaseAddress) })
            {
                var httpResponse = await client.GetAsync($"{productsResource}/{productId}");

                if (httpResponse.IsSuccessStatusCode == false)
                    throw new DependencyApiException(productsResource, productId);

                var jsonString = await httpResponse.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<ProductModel>(jsonString);

                return product;
            }
        }
    }
}
