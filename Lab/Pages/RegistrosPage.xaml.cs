using Lab.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab.Pages
{

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrosPage : ContentPage
	{

		HttpClient client = new HttpClient();
		public RegistrosPage ()
		{
			InitializeComponent ();
		}

		private async void ObtenerRegistros()
        {
			var token = await SecureStorage.GetAsync("Token");

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

			string url = "https://saludomar.azurewebsites.net/api/salud/";

			var resultado = await client.GetAsync(url);

            if (resultado.IsSuccessStatusCode)
			{
				var resultadoJson = resultado.Content.ReadAsStringAsync().Result;

				List<IMC> listaRegistros = new List<IMC>();

				listaRegistros = IMC.FromJson(resultadoJson);

				ListView listView = new ListView();

				listView.ItemsSource = listaRegistros;
            }
			else
            {
				await DisplayAlert("Error", "Error al cargar datos", "OK");
            }


        }

	}
}