using System;
using FakeStoreApp.Models;
using Microsoft.Maui.Controls;

namespace FakeStoreApp.Pages
{
    public partial class ConsultarProductoPage : ContentPage
    {
        private readonly ApiService _apiService;

        public ConsultarProductoPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
        }

        private async void BuscarProducto_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(ProductoIdEntry.Text, out int productoId))
            {
                var producto = await _apiService.GetProductByIdAsync(productoId);
                if (producto != null)
                {
                    ProductoDetallesLabel.Text = $"Nombre: {producto.Title}\nPrecio: {producto.Price}\nDescripción: {producto.Description}";
                }
                else
                {
                    await DisplayAlert("Error", "Producto no encontrado", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Por favor ingrese un ID válido", "OK");
            }
        }
    }
}
