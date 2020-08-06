using System.Threading.Tasks;

namespace Insurance.Domain.Repositories
{
    public interface IProductRepository
    {
        Task<Models.ProductModel> GetProduct(int productId);
        Task<Models.ProductTypeModel> GetProductType(int productTypeId);
    }
}