using Microsoft.EntityFrameworkCore;
using MVC_CSharp.Models;

namespace MVC_CSharp.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).ToList();
        }

        public void CreateProduct(Product value)
        {
            _context.Products.Add(value);
            _context.SaveChanges();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void UpdateProduct(Product value)
        {
            var value1 = GetProductById(value.Id);
            if (value1 != null)
            {
                value1.Name = value.Name;
                value1.Slug = value.Slug;
                value1.Quantity = value.Quantity;
                value1.Price = value.Price;
                value1.CategoryId = value.CategoryId;
                _context.Products.Update(value1);
                _context.SaveChanges();
            }
        }

        public void DeleteProduct(int id)
        {
            var value = GetProductById(id);
            if (value != null)
            {
                _context.Products.Remove(value);
                _context.SaveChanges();
            }
            else return;
        }
    }
}
