using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProtoDevDemo.ViewModels
{
    public class PaginaPrincipalViewModel
    {
        public ICommand VerCatalogoCommand { get; }
        public ICommand VerCarritoComprasCommand { get; }

        public PaginaPrincipalViewModel()
        {
            VerCatalogoCommand = new Command(VerCatalogo);
            VerCarritoComprasCommand = new Command(VerCarritoCompras);
        }

        private void VerCatalogo()
        {
            Shell.Current.GoToAsync("//MainPage");
        }

        private void VerCarritoCompras()
        {
            Shell.Current.GoToAsync("//CartPage");
        }
    }
}