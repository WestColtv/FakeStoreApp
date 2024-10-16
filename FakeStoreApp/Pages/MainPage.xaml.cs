
using System;
using Microsoft.Maui.Controls;

namespace FakeStoreApp.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Evento para ir a la página de consulta de un producto
        private async void BtnIrAConsultarProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ConsultarProductoPage());
        }

        // Evento para ir a la página de creación de un producto
        private async void BtnIrACrearProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearProductoPage());
        }

        // Evento para ir a la página de listado de productos
        private async void BtnIrAListarProductos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListarProductosPage());
        }

        // Evento para ir a la página de actualización de un producto
        private async void BtnIrAActualizarProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActualizarProductoPage());
        }

        // Evento para ir a la página de eliminación de un producto
        private async void BtnIrAEliminarProducto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EliminarProductoPage());
        }
    }
}
