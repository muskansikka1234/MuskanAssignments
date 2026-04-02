using CodeFirstEFDemo.Data;
using CodeFirstEFDemo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstEFDemo
{
    class ProductRepository2 : IProductRepository
    {

        private readonly AppDbContext _context;

        public ProductRepository2(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> AddAsync(Product product)
        {
            var result = await _context.Products.FromSqlRaw($"EXEC InsertProduct" +
                $" {product.Name},{product.Price},{product.CategoryId}").ToListAsync();
            return result.First();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.FromSqlRaw("EXEC GetAllProducts").ToListAsync();
        }

        public Task<List<Product>> GetByCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            var products = await _context.Products.FromSqlRaw($"EXEC GetProductById : {id}").ToListAsync();
            return products.FirstOrDefault();
        }

        public async Task UpdateAsync(Product product)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC UpdateProduct {product.Id}," + $"{product.Name},{product.Price},{product.CategoryId}");
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Database.ExecuteSqlRawAsync($"EXEC DeleteProduct {id}");
        }
    }
}
