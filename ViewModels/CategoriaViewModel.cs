using ProtoDevDemo.Models;
using ProtoDevDemo.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace ProtoDevDemo.ViewModels
{
    public class CategoriaViewModel : INotifyPropertyChanged
    {
        private List<Producto> _model;
        public List<Producto> Model
        {
            get => _model;
            set
            {
                if (value != _model)
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }

        public ICommand ComandoRetornarPDDs { get; }
        public ICommand ComandoRetornarSBCs { get; }
        public ICommand ComandoRetornarIntegrados { get; }
        public ICommand ComandoRetornarAccesorios { get; }
        public ICommand ComandoRetornarVarios { get; }
        public ICommand IrAlCarritoCommand { get; }
        public ICommand ComandoGuardarAlCarrito { get; }


        public ProtoBDRepo BDRepo { get; set; }

        // Constructor
        public CategoriaViewModel()
        {
            Model = new List<Producto>();
            

            // Inicializa los comandos
            ComandoRetornarPDDs = new Command(async () => await RetornarPlacasDesarrollo());
            ComandoRetornarSBCs = new Command(async () => await RetornarSBC());
            ComandoRetornarIntegrados = new Command(async () => await RetornarIntegrados());
            ComandoRetornarAccesorios = new Command(async () => await RetornarAccesorios());
            ComandoRetornarVarios = new Command(async () => await RetornarVarios());
            IrAlCarritoCommand = new Command(IrAlCarrito);
            ComandoGuardarAlCarrito = new Command<Producto>(GuardarAlCarrito);
            // Ejecutar el comando al inicio
            ComandoRetornarVarios.Execute(null);
        }
        private async void GuardarAlCarrito(Producto producto)
        {
            // Primero, verifica si el producto ya está en el carrito de compras
            var productoExistente = App.ProtoBDRepo.DevuelveListadoCarritoCompras().FirstOrDefault(p => p.NombreProductoCarrito == producto.Nombre);

            // Si el producto ya está en el carrito de compras, muestra un mensaje y termina el método
            if (productoExistente != null)
            {
                await Shell.Current.DisplayAlert("Producto ya en el carrito", "Este producto ya se encuentra en el carrito de compras.", "OK");
                return;
            }

            // Si el producto no está en el carrito de compras, continúa con la lógica existente para agregarlo
            CarritoCompras nuevoProducto = new CarritoCompras
            {
                id = producto.Id,
                NombreProductoCarrito = producto.Nombre,
                PrecioCarrito = producto.Precio,
                cantidad = 1,
                Total = producto.Precio,
                ImagenCarrito = producto.Imagen
            };
            App.ProtoBDRepo.GuardarProductoCarritoCompras(nuevoProducto);

            // Muestra un mensaje de alerta
            await Shell.Current.DisplayAlert("Producto guardado", "El producto ha sido guardado en el carrito de compras.", "OK");
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public async Task RetornarPlacasDesarrollo()
        {
            ProductsRepo repo = new ProductsRepo();
            List<Producto> productos = await repo.RetornaPDD();
            Model = productos;
        }

        public async Task RetornarSBC()
        {
            ProductsRepo repo = new ProductsRepo();
            List<Producto> productos = await repo.RetornaSBC();
            Model = productos;
        }

        public async Task RetornarIntegrados()
        {
            ProductsRepo repo = new ProductsRepo();
            List<Producto> productos = await repo.RetornaIntegrado();
            Model = productos;
        }

        public async Task RetornarAccesorios()
        {
            ProductsRepo repo = new ProductsRepo();
            List<Producto> productos = await repo.RetornaAccesorio();
            Model = productos;
        }

        public async Task RetornarVarios()
        {
            ProductsRepo repo = new ProductsRepo();
            List<Producto> productos = await repo.RetornaVarios();
            Model = productos;
        }

        private void IrAlCarrito()
        {
            // Navega a CartPage
            Shell.Current.GoToAsync("//CartPage");
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}