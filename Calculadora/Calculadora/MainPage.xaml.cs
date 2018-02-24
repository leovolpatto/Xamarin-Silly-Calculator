using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Calculadora.ViewModels;

namespace Calculadora
{
    public partial class MainPage : ContentPage
    {
        private CalculadoraViewModel calculadoraVM{get;set;}
        
		public MainPage()
		{
            this.BindingContext = this.calculadoraVM = new CalculadoraViewModel();

            this.InitializeComponent();
            this.addEvents();
		}

        private void addEvents()
        {
            var bots = this.FindByName<Grid>("grid").Children.OfType<Button>();

            bots.ToList().ForEach(b =>
            {
                b.Clicked += this.botaoClick;
            });
        }

        private void botaoClick(object sender, EventArgs e)
        {
            this.calculadoraVM.Display += (sender as Button).Text;
            this.calculadoraVM.Informar((sender as Button).Text);
        }
    }
}
