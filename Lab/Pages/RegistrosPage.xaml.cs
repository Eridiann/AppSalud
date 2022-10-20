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
			ObtenerRegistros();
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

				listView.ItemTemplate = new DataTemplate(() =>
                {
					Label peso = new Label();
					peso.SetBinding(Label.TextProperty, "Peso");

					Label altura = new Label();
					altura.SetBinding(Label.TextProperty, "Altura");

					Label imc = new Label();
					imc.SetBinding(Label.TextProperty, "Imc");


					return new ViewCell
					{
						View = new StackLayout
						{
							Orientation = StackOrientation.Vertical,
							VerticalOptions = LayoutOptions.Center,
							Children =
							{
								new StackLayout
								{
									Orientation = StackOrientation.Horizontal,
									VerticalOptions = LayoutOptions.Center,
									Children =
									{
										peso, altura, imc
									}
								}
							}
						}
					};
				});
				this.Content = new StackLayout
				{
					Children =
                    {
						listView
                    }
				};
            }
			else
            {
				await DisplayAlert("Error", "Error al cargar datos", "OK");
            }


        }

	}
}