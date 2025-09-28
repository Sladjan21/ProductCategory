using Models.DTOs;
using Models.DTOs.Product;
using System.Net.Http.Json;
using System.Text.Json;

namespace GUI.APIClient;
public class ApiClient
{
    private readonly HttpClient _httpClient;
    private readonly string GetProducts = "Home/GetAllProducts";
    private readonly string GetCategories = "Home/GetAllCategories";
    private readonly string AddProduct = "Home/AddProduct";
    private readonly string DeleteProduct = "Home/DeleteProduct?productId=";
    private readonly string UpdateProductUrl = "Home/UpdateProduct";
    public ApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductDTO>> GetProductsAsync()
    {
        var response = await _httpClient.GetAsync(GetProducts);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var products = JsonSerializer.Deserialize<List<ProductDTO>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return products ?? new List<ProductDTO>();
    }

    public async Task<List<CategoryDTO>> GetCategoriesAsync()
    {
        var response = await _httpClient.GetAsync(GetCategories);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var categories = JsonSerializer.Deserialize<List<CategoryDTO>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return categories ?? new List<CategoryDTO>();
    }

    public async Task<bool> PostProductAsync(ProductCreateDTO dto)
    {
        var response = await _httpClient.PostAsJsonAsync(AddProduct, dto);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        var response = await _httpClient.GetAsync($"{DeleteProduct}{id}");

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateProduct(ProductDTO product)
    {
        var response = await _httpClient.PostAsJsonAsync(UpdateProductUrl, product);

        return response.IsSuccessStatusCode;
    }
}
