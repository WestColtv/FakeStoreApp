using System;
using FakeStoreApp.Models;
using Microsoft.Maui.Controls;

namespace FakeStoreApp.Pages
{
    public partial class EliminarProductoPage : ContentPage
    {
        private readonly ApiService _apiService;

        public EliminarProductoPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void EliminarProducto_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(ProductoIdEntry.Text) || !int.TryParse(ProductoIdEntry.Text, out int productoId))
            {
                await DisplayAlert("Error", "Ingrese un ID válido.", "OK");
                return;
            }

            IsBusy = true;
            try
            {
                var isDeleted = await _apiService.DeleteProductAsync(productoId);
                if (isDeleted)
                {
                    await DisplayAlert("Éxito", "Producto eliminado con éxito", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo eliminar el producto", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al eliminar el producto: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
