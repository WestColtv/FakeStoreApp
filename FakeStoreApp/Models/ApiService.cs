using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FakeStoreApp.Models
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://fakestoreapi.com";

        public ApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        // Obtener todos los productos
        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Product>>("/products");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
                return new List<Product>();  // Devolver una lista vacía en caso de error
            }
        }

        // Obtener un producto por su ID
        public async Task<Product> GetProductByIdAsync(int productId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Product>($"/products/{productId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener producto con ID {productId}: {ex.Message}");
                return null;  // Devolver null en caso de error
            }
        }

        // Crear un nuevo producto
        public async Task<bool> AddProductAsync(Product newProduct)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/products", newProduct);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear producto: {ex.Message}");
                return false;
            }
        }

        // Actualizar un producto existente
        public async Task<bool> UpdateProductAsync(int productId, Product updatedProduct)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"/products/{productId}", updatedProduct);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar producto con ID {productId}: {ex.Message}");
                return false;
            }
        }

        // Eliminar un producto por su ID
        public async Task<bool> DeleteProductAsync(int productId)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/products/{productId}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto con ID {productId}: {ex.Message}");
                return false;
            }
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
    }
}
