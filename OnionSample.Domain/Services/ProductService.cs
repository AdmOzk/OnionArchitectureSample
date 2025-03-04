using OnionSample.Domain.Entities;
using OnionSample.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnionSample.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            // When created by a seller, set status to Pending.
            product.Status = ProductStatus.Pending;
            await _productRepository.AddAsync(product);
            return product;
        }

        public async Task UpdateProductForSellerAsync(Product product, int sellerId)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.ProductId);
            if (existingProduct == null)
                throw new Exception("Product not found.");
            if (existingProduct.SellerId != sellerId)
                throw new UnauthorizedAccessException("You can update only your own products.");

            // Update allowed fields.
            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.Image = product.Image;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;

            await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task UpdateProductForAdminAsync(Product product)
        {
            var existingProduct = await _productRepository.GetByIdAsync(product.ProductId);
            if (existingProduct == null)
                throw new Exception("Product not found.");

            existingProduct.Title = product.Title;
            existingProduct.Description = product.Description;
            existingProduct.Image = product.Image;
            existingProduct.Price = product.Price;
            existingProduct.Stock = product.Stock;
            existingProduct.SellerId = product.SellerId;
            // Update status based on provided business rules.
            if (product.Status == ProductStatus.Approved)
                existingProduct.Status = ProductStatus.Approved;
            else if (product.Status == ProductStatus.Rejected)
                existingProduct.Status = ProductStatus.Rejected;
            else
                existingProduct.Status = ProductStatus.Pending;

            await _productRepository.UpdateAsync(existingProduct);
        }

        public async Task<string> PurchaseProductAsync(int productId, int quantity)
        {
            var product = await _productRepository.GetByIdAsync(productId);
            if (product == null)
                throw new Exception("Product not found.");
            if (product.Status != ProductStatus.Approved)
                throw new Exception("Product is not available for purchase.");
            if (product.Stock < quantity)
                throw new Exception("Not enough stock available.");
            product.Stock -= quantity;
            await _productRepository.UpdateAsync(product);
            return "Purchase successful!";
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetByIdAsync(id);
        }
    }
}
