using GUI.APIClient;
using Models.DTOs;
using Models.DTOs.Product;
using System.Data;

namespace GUI
{
    public partial class AddProductForm : Form
    {
        private readonly ApiClient _apiClient;

        public AddProductForm(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ProductCreateDTO productDto = new ProductCreateDTO
            {
                Name = tbName.Text,
                Price = (double)numPrice.Value,
                Quantity = (int)numQuantity.Value,
                Description = tbDescription.Text

            };

            var categories = cblCategory.CheckedItems.OfType<CategoryDTO>();

            productDto.Categories = categories.Select(x => x.Id).ToList();

            var succesfull = await _apiClient.PostProductAsync(productDto);

            if (succesfull)
            {
                MessageBox.Show("Uspesno dodat");
                this.Close();
            }
            else
                MessageBox.Show("Doslo je do greske");

        }

        private async void AddProductForm_Load(object sender, EventArgs e)
        {
            var categories = await _apiClient.GetCategoriesAsync();

            cblCategory.DataSource = categories;
            cblCategory.DisplayMember = nameof(CategoryDTO.Name);
            cblCategory.ValueMember = nameof(CategoryDTO.Id);

        }
    }
}
