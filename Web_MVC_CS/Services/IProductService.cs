using MVC_CS.Models;

namespace MVC_CS.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        Product GetProductById(int id);

        void CreateProduct(Product value);

        void UpdateProduct(Product value);

        void DeleteProduct(int id);

        List<Category> GetCategories();
    }

}
