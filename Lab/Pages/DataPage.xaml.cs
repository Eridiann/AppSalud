using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {
        public DataPage(string nombre)
        {
            InitializeComponent();
            lblNombre.Text = nombre;
            btnIMC.Clicked += BtnIMC_Clicked;
        }

        private void BtnIMC_Clicked(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = lblNombre.Text;
            persona.Edad = int.Parse(txtEdad.Text);
            persona.Peso = float.Parse(txtPeso.Text);
            persona.Altura = float.Parse(txtAltura.Text);

            Navigation.PushAsync(new IMCPage(persona));
        }
    }
}