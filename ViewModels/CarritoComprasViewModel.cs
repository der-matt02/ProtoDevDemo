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

namespace ProtoDevDemo.ViewModels
{
    public class CarritoComprasViewModel : INotifyPropertyChanged
    {
        private List<CarritoCompras> _model;
        public List<CarritoCompras> Model
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
        // Comandos
        public ICommand ComandoGuardarAlCarrito { get; }
        public ICommand ComandoEliminarDelCarrito { get; }
        public ICommand ComandoActualizarCarrito { get; }
        public ICommand IrALaPaginaPrincipalCommand { get; }
        public ICommand DevuelveListadoCarritoComprasCommand { get; }
        public ICommand ComandoAumentarCantidad { get; }
        public ICommand ComandoDisminuirCantidad { get; }
        public ICommand ComandoCalculoSubtotal { get; }
        public double Subtotal { get; set; }

        // Nuevo comando
        public ProtoBDRepo BDRepo { get; set; }

        // Constructor
        public CarritoComprasViewModel()
        {
            ComandoCalculoSubtotal = new Command(CalculoSubtotal);
            // Inicializa los comandos
            ComandoAumentarCantidad = new Command<CarritoCompras>(AumentarCantidad);
            ComandoDisminuirCantidad = new Command<CarritoCompras>(DisminuirCantidad);

            // Inicializa los comandos
            ComandoEliminarDelCarrito = new Command<CarritoCompras>(EliminarDelCarrito);
            ComandoActualizarCarrito = new Command<CarritoCompras>(ActualizarCarrito);
            IrALaPaginaPrincipalCommand = new Command(IrALaPaginaPrincipal);
            DevuelveListadoCarritoComprasCommand = new Command(DevuelveListadoCarritoCompras); // Inicialización del nuevo comando
        }
        private void CalculoSubtotal()
        {
            // Obtiene todos los productos en el carrito de compras
            var productos = App.ProtoBDRepo.DevuelveListadoCarritoCompras();

            // Verifica si el carrito de compras está vacío


            // Si el carrito de compras no está vacío, calcula el subtotal sumando el total de cada producto
            Subtotal = productos.Sum(producto => producto.Total);

            // Notifica que el subtotal ha cambiado
            OnPropertyChanged(nameof(Subtotal));
        }


        private void AumentarCantidad(CarritoCompras producto)
        {
            producto.cantidad++;
            producto.Total = producto.PrecioCarrito * producto.cantidad;
            App.ProtoBDRepo.ActualizarProductoCarritoCompras(producto);
            Model = App.ProtoBDRepo.DevuelveListadoCarritoCompras();
            ComandoCalculoSubtotal.Execute(null);
            //OnPropertyChanged(nameof(Subtotal)); // Notifica que el subtotal ha cambiado
        }


        private void DisminuirCantidad(CarritoCompras producto)
        {
            if (producto.cantidad > 1)
            {
                producto.cantidad--;
                producto.Total = producto.PrecioCarrito * producto.cantidad;
                App.ProtoBDRepo.ActualizarProductoCarritoCompras(producto);
                Model = App.ProtoBDRepo.DevuelveListadoCarritoCompras();
                ComandoCalculoSubtotal.Execute(null);
                //OnPropertyChanged(nameof(Subtotal)); // Notifica que el subtotal ha cambiado
            }
        }




        private void EliminarDelCarrito(CarritoCompras producto)
        {
            // Elimina el producto del carrito de compras
            App.ProtoBDRepo.EliminarProductoCarritoCompras(producto);
            Model = App.ProtoBDRepo.DevuelveListadoCarritoCompras();
            ComandoCalculoSubtotal.Execute(null);
        }

        private void ActualizarCarrito(CarritoCompras producto)
        {
            // Actualiza el producto en el carrito de compras
            App.ProtoBDRepo.ActualizarProductoCarritoCompras(producto);
        }

        private void IrALaPaginaPrincipal()
        {
            // Navega a MainPage
            Shell.Current.GoToAsync("//MainPage");
        }

        private async void DevuelveListadoCarritoCompras() // Nuevo método
        {
            var productos = App.ProtoBDRepo.DevuelveListadoCarritoCompras();

            if (!productos.Any())
            {
                // Si el carrito de compras está vacío, muestra un mensaje al usuario y termina el método
                await Shell.Current.DisplayAlert("Carrito vacío", "El carrito de compras está vacío.", "OK");
                return;
            }
            // Devuelve el listado de productos del carrito de compras
            Model = App.ProtoBDRepo.DevuelveListadoCarritoCompras();
            ComandoCalculoSubtotal.Execute(null);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}