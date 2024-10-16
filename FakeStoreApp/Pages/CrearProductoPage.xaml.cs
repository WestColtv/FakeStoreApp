using System;
using FakeStoreApp.Models;
using Microsoft.Maui.Controls;

namespace FakeStoreApp.Pages
{
    public partial class CrearProductoPage : ContentPage
    {
        private readonly ApiService _apiService;

        public CrearProductoPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void CrearProducto_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NombreProductoEntry.Text) ||
                string.IsNullOrWhiteSpace(PrecioProductoEntry.Text) ||
                string.IsNullOrWhiteSpace(DescripcionProductoEditor.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (!decimal.TryParse(PrecioProductoEntry.Text, out decimal precio))
            {
                await DisplayAlert("Error", "Precio inválido.", "OK");
                return;
            }

            var nuevoProducto = new Product
            {
                Title = NombreProductoEntry.Text,
                Price = precio,
                Description = DescripcionProductoEditor.Text
            };

            IsBusy = true;
            try
            {
                var isCreated = await _apiService.AddProductAsync(nuevoProducto);
                if (isCreated)
                {
                    await DisplayAlert("Éxito", "Producto creado con éxito", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo crear el producto", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al crear el producto: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
