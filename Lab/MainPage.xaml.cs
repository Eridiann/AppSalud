using Lab.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnEntrar.Clicked += BtnEntrar_Clicked;
        }

        private void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            if(txtNombre.Text == null || txtNombre.Text.Length == 0)
            {
                DisplayAlert("Error", "Captura tu nombre", "OK");
            }
            else
            {
                Navigation.PushAsync(new DataPage(txtNombre.Text.ToString()));
            }
        }
    }
}
