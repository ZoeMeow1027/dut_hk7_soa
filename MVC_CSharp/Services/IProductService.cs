using MVC_CSharp.Models;

namespace MVC_CSharp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();

        List<Category> GetCategories();

        Product? GetProductById(int id);

        void CreateProduct(Product value);

        void UpdateProduct(Product value);

        void DeleteProduct(int id);
    }
}
