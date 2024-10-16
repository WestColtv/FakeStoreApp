using System;
using FakeStoreApp.Models;
using Microsoft.Maui.Controls;

namespace FakeStoreApp.Pages
{
    public partial class ActualizarProductoPage : ContentPage
    {
        private readonly ApiService _apiService;

        public ActualizarProductoPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void ActualizarProducto_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductoIdEntry.Text) ||
                string.IsNullOrWhiteSpace(NombreProductoEntry.Text) ||
                string.IsNullOrWhiteSpace(PrecioProductoEntry.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                return;
            }

            if (!int.TryParse(ProductoIdEntry.Text, out int productoId) || !decimal.TryParse(PrecioProductoEntry.Text, out decimal precio))
            {
                await DisplayAlert("Error", "ID o precio inválidos.", "OK");
                return;
            }

            var productoActualizado = new Product
            {
                Title = NombreProductoEntry.Text,
                Price = precio,
                Description = DescripcionProductoEditor.Text
            };

            IsBusy = true;
            try
            {
                var isUpdated = await _apiService.UpdateProductAsync(productoId, productoActualizado);
                if (isUpdated)
                {
                    await DisplayAlert("Éxito", "Producto actualizado con éxito", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo actualizar el producto", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al actualizar el producto: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
