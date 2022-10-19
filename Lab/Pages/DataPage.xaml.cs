using Lab.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DataPage : ContentPage
    {

        HttpClient httpClient = new HttpClient();
        
        public DataPage(string nombre)
        {
            InitializeComponent();
            lblNombre.Text = nombre;
            btnIMC.Clicked += BtnIMC_Clicked;
        }

        private async void BtnIMC_Clicked(object sender, EventArgs e)
        {
            Persona persona = new Persona();
            persona.Nombre = lblNombre.Text;
            persona.Edad = int.Parse(txtEdad.Text);
            persona.Peso = float.Parse(txtPeso.Text);
            persona.Altura = float.Parse(txtAltura.Text);

            //Navigation.PushAsync(new IMCPage(persona));


            var token = await Xamarin.Essentials.SecureStorage.GetAsync("Token");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var url = "https://saludomar.azurewebsites.net/api/salud";

            IMC imc = new IMC();
            imc.Altura = float.Parse(txtAltura.Text);
            imc.Peso = float.Parse(txtPeso.Text);
            imc.Imc = imc.Peso / (imc.Altura * imc.Altura);

            string imcJson = JsonConvert.SerializeObject(imc);
            StringContent content = new StringContent(imcJson, Encoding.UTF8, "application/json");

            var respuesta = await httpClient.PostAsync(url, content);

            if (respuesta.IsSuccessStatusCode)
            {
                await DisplayAlert("OK", "Registro Guardado", "OK");
            }
            else
            {
                
                await DisplayAlert("Error", "Hubo un problema al guardar\n" + respuesta.ToString(), "OK");
            }

        }


    }
}