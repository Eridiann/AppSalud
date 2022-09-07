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
    public partial class RecomendacionesPage : ContentPage
    {
        public RecomendacionesPage(string Resultado)
        {
            InitializeComponent();
            lblCondicion.Text = Resultado;

            if(lblCondicion.Text == "Peso bajo")
            {
                lblRecomendacion.Text = "Come más!";
                lblMensaje.Text = "Te vas morir de ambre";
            }
            if(lblCondicion.Text == "Saludable")
            {
                lblRecomendacion.Text = "Cuidado con las fiestas";
                lblMensaje.Text = "Estas saludable";
            }
            if(lblCondicion.Text == "Obesidad")
            {
                lblRecomendacion.Text = "Haz dieta o ejercicio";
                lblMensaje.Text = "Estas en situacion de riesgo";
            }
            if(lblCondicion.Text == "Obesidad Severa")
            {
                lblRecomendacion.Text = "Haz dieta Y haz ejercicio";
                lblMensaje.Text = "Estas en situacion de alto riesgo";
            }
            
        }
    }
}