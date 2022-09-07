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
    public partial class IMCPage : ContentPage
    {
        public IMCPage(Persona persona)
        {
            InitializeComponent();
            aiCargando.IsRunning = true;
            btnRecomendaciones.IsEnabled = false;

            aiCargando.IsRunning = false;

            var IMC = persona.Peso / (persona.Altura * persona.Altura);

            if (IMC < 18.5)
            {
                lblResult.Text = "Peso bajo";
                lblResult.BackgroundColor = Color.DarkRed;
                imgIMC.Source = new Uri("https://i.pinimg.com/600x315/8a/5c/44/8a5c44357dd806a6b816a19d047d343c.jpg");
            }
            else if (IMC < 25)
            {
                lblResult.Text = "Saludable";
                lblResult.BackgroundColor = Color.DarkGreen;
                imgIMC.Source = new Uri("https://static.wikia.nocookie.net/ssbb/images/2/23/Entrenadora_de_Wii_Fit_SSBU.png/revision/latest?cb=20190726104718&path-prefix=es");
            }
            else if (IMC < 30)
            {
                lblResult.Text = "Obesidad";
                lblResult.BackgroundColor = Color.Orange;
                imgIMC.Source = new Uri("https://static.wikia.nocookie.net/shrek/images/3/3f/Portada_img.jpg/revision/latest?cb=20100719002911&path-prefix=es");
            }
            else
            {
                lblResult.Text = "Obesidad Severa";
                lblResult.BackgroundColor = Color.DarkRed;
                imgIMC.Source = new Uri("https://static.wikia.nocookie.net/hollowknight/images/2/24/Bardoon.png/revision/latest?cb=20180212215159&path-prefix=es");
            }

            btnRecomendaciones.IsEnabled = true;

            btnRecomendaciones.Clicked += BtnRecomendaciones_Clicked;
        }

        private void BtnRecomendaciones_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RecomendacionesPage(lblResult.Text));
        }
    }
}