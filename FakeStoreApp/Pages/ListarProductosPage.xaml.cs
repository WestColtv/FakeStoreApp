using System;
using System.Collections.ObjectModel;
using FakeStoreApp.Models;
using Microsoft.Maui.Controls;

namespace FakeStoreApp.Pages
{
    public partial class ListarProductosPage : ContentPage
    {
        private readonly ApiService _apiService;
        public ObservableCollection<Product> Productos { get; set; }

        public ListarProductosPage()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Productos = new ObservableCollection<Product>();
            ProductosListView.ItemsSource = Productos; // Conecta la lista observable a la ListView en el XAML.
            CargarProductos();
        }

        private async void CargarProductos()
        {
            IsBusy = true; // Muestra un indicador de carga en la UI.
            try
            {
                var productos = await _apiService.GetAllProductsAsync(); // Llama al servicio API para obtener todos los productos.

                if (productos != null)
                {
                    Productos.Clear(); // Limpia la lista observable antes de agregar nuevos productos.
                    foreach (var producto in productos)
                    {
                        Productos.Add(producto); // Agrega cada producto a la colección observable.
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Error al cargar productos: {ex.Message}", "OK"); // Muestra un mensaje de error si algo sale mal.
            }
            finally
            {
                IsBusy = false; // Oculta el indicador de carga cuando finalice la operación.
            }
        }
    }
}
