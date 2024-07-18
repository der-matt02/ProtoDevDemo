using Microsoft.Maui.Controls;
using ProtoDevDemo.ViewModels;
using System.Windows.Input;

namespace ProtoDevDemo.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch (picker.ItemsSource[selectedIndex])
                {
                    case "PDDs":
                        (BindingContext as CategoriaViewModel).ComandoRetornarPDDs.Execute(null);
                        break;
                    case "SBCs":
                        (BindingContext as CategoriaViewModel).ComandoRetornarSBCs.Execute(null);
                        break;
                    case "Integrados":
                        (BindingContext as CategoriaViewModel).ComandoRetornarIntegrados.Execute(null);
                        break;
                    case "Accesorios":
                        (BindingContext as CategoriaViewModel).ComandoRetornarAccesorios.Execute(null);
                        break;
                }
            }
        }
    }
}