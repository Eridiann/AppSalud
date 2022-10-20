using Lab.Models;
using Lab.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Lab
{
    public partial class MainPage : ContentPage
    {

        private readonly HttpClient _httpClient = new HttpClient();

        public MainPage()
        {
            InitializeComponent();
            btnEntrar.Clicked += BtnEntrar_Clicked;
            btnRegistrar.Clicked += BtnRegistrar_Clicked;
        }

        private async void BtnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (txtNombre.Text == null || txtNombre.Text.Length == 0 ||
                txtPassword == null || txtPassword.Text.Length == 0 ||
                txtEmail == null || txtEmail.Text.Length == 0)
            {
                await DisplayAlert("Error", "Captura tu nombre", "OK");
            }
            else
            {
                Usuario usuario = new Usuario
                {
                    username = txtNombre.Text,
                    password = txtPassword.Text,
                    email = txtEmail.Text,
                };

                string json = JsonConvert.SerializeObject(usuario);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = "https://saludomar.azurewebsites.net/api/cuentas/registrar";

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Token token = new Token();
                    token = JsonConvert.DeserializeObject<Token>(result);

                    string miToken = token.TokenToken.ToString();
                    await SecureStorage.SetAsync("Token", miToken);
                    await Navigation.PushAsync(new DataPage(txtNombre.Text.ToString()));
                }
                else
                {
                    await DisplayAlert("Error", "Credenciales invalidas o servidor inaccesible", "OK");
                }

            }
        }

        private async void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            if(txtNombre.Text == null || txtNombre.Text.Length == 0 ||
                txtPassword == null || txtPassword.Text.Length == 0 ||
                txtEmail == null || txtEmail.Text.Length == 0)
            {
                await DisplayAlert("Error", "Captura tu nombre", "OK");
            }
            else
            {
                Usuario usuario = new Usuario
                {
                    username = txtNombre.Text,
                    password = txtPassword.Text,
                    email = txtEmail.Text,
                };

                string json = JsonConvert.SerializeObject(usuario);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                string url = "https://saludomar.azurewebsites.net/api/cuentas/login";

                var response = await _httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    Token token = new Token();
                    token = JsonConvert.DeserializeObject<Token>(result);

                    string miToken = token.TokenToken.ToString();
                    await SecureStorage.SetAsync("Token", miToken);
                    //await Navigation.PushAsync(new DataPage(txtNombre.Text.ToString()));
                    await Navigation.PushAsync(new RegistrosPage());
                }
                else
                {
                    await DisplayAlert("Error", "Credenciales invalidas o servidor inaccesible", "OK");
                }

            }
        }
    }
}
