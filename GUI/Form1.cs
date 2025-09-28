using GUI.APIClient;
using Microsoft.Extensions.DependencyInjection;
using Models.DTOs;
using System.ComponentModel;

namespace GUI
{
    public partial class Form1 : Form
    {
        private readonly ApiClient _apiClient;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<ProductDTO>? productBindingList;
        private bool initializing;
        public Form1(ApiClient apiClient, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _apiClient = apiClient;
            _serviceProvider = serviceProvider;
        }

        private async void Form1_LoadAsync(object sender, EventArgs e)
        {
            initializing = true;

            var products = await _apiClient.GetProductsAsync();
            var categories = await _apiClient.GetCategoriesAsync();

            productBindingList = new BindingList<ProductDTO>(products);

            dgProducts.DataSource = productBindingList;
            dgProducts.Columns[0].ReadOnly = true;

            cbCategory.DataSource = categories;

            cbCategory.ValueMember = nameof(CategoryDTO.Id);
            cbCategory.DisplayMember = nameof(CategoryDTO.Name);

            cbCategory.SelectedIndex = -1;
            cbCategory.Text = string.Empty;

            initializing = false;
        }

        private async void btnAddProduct_Click(object sender, EventArgs e)
        {
            var addProductForm = _serviceProvider.GetRequiredService<AddProductForm>();
            addProductForm.ShowDialog();
            await RefreshGridData();
        }

        private async Task RefreshGridData()
        {
            var products = await _apiClient.GetProductsAsync();
            productBindingList = new BindingList<ProductDTO>(products);
            dgProducts.DataSource = productBindingList;
            dgProducts.Refresh();
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue is int catId && !initializing)
            {
                dgProducts.DataSource = productBindingList.Where(x => x.Categories.Contains(catId)).ToList();

                dgProducts.Refresh();
            }
        }

        private async void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (dgProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Morate da izaberete 1 proizvod koji hocete da obrisete!");
                return;
            }

            if (dgProducts.SelectedRows.Count > 1)
            {
                MessageBox.Show("Izabrali ste vise od 1 za brisanje!");
                return;
            }


            if (dgProducts.SelectedRows[0].DataBoundItem is ProductDTO obj)
            {

                if (obj.Id < 0)
                {
                    MessageBox.Show("Nesto nije u redu!");
                    return;
                }

                var isDeleted = await _apiClient.DeleteProductAsync(obj.Id);

                if (isDeleted)
                {
                    MessageBox.Show("Uspesno izbrisan!");
                    productBindingList.Remove(obj);
                }
                else
                    MessageBox.Show("Nesto nije u redu");
            }
        }

        private async void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            var allSuccess = true;
        
            foreach (var item in productBindingList)
            {
                var isSucess = await _apiClient.UpdateProduct(item);

                if (!isSucess)
                    allSuccess = false;
            }

            if (allSuccess)
                MessageBox.Show("Usepsno azuriranje");
            else
                MessageBox.Show("Neuspesno azuriranje");

            dgProducts.Refresh();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            dgProducts.DataSource = productBindingList;

            cbCategory.SelectedIndex = -1;

            dgProducts.Refresh();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshGridData();
        }
    }
}
