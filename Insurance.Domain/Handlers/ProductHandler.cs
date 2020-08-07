using Insurance.Domain.Commands;
using Insurance.Domain.Commands.Results;
using Insurance.Domain.Entities;
using Insurance.Domain.Repositories;
using Insurance.Shared.Commands;
using System;
using System.Threading.Tasks;

namespace Insurance.Domain.Handlers
{
    public class ProductHandler : ICommandHandler<CalculateInsurance>
    {
        private IProductRepository _repository;

        public ProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ICommandResult> Handle(CalculateInsurance command)
        {
            try
            {
                var productModel = await _repository.GetProduct(command.ProductId);

                if (productModel == null)
                    return new NotFoundCommandResult($"Product with Id {command.ProductId} could not be found");

                var productTypeModel = await _repository.GetProductType(productModel.ProductTypeId);

                if (productTypeModel == null)
                    return new NotFoundCommandResult($"Relationship between product Id {command.ProductId} and its type seems to be wrong");

                var productType = new ProductType(productTypeModel.Name, productTypeModel.CanBeInsured);
                var product = new Product(productType, productModel.SalesPrice);

                return new SuccessCommandResult("Customer created.", product.InsuranceValue);
            }
            catch (Exception ex)
            {
                // Add Log here
                return new ErrorCommandResult($"Unexpected error while rendling the calculation of insurance for product {command.ProductId}", ex);
            }
            finally
            {
                //Add monitoring here
            }
        }
    }
}
