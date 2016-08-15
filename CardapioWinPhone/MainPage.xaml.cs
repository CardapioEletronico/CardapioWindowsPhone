using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using CardapioWinPhone.Resources;
using System.Net.Http;
using Newtonsoft.Json;

namespace CardapioWinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        private string ip = "http://10.21.0.137/";
        // Constructor
        public MainPage()
        {
            InitializeComponent();

             

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }



        private async void Carregar_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("20131011110061/api/cardapio");

            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Cardapio> obj = JsonConvert.DeserializeObject<List<Models.Cardapio>>(str);


            foreach (var bo in obj)
            {
                Button txt = new Button();
                txt.Content = "";
                txt.Content = bo.Descricao.ToString();
                StackLapa.Children.Add(txt);
            }
        }
  

    private async void txt_Click(object sender, RoutedEventArgs e)
        {

            HttpClient httpClient = new HttpClient();


            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/20131011110061/api/cardapio");

            ListaProduto Lproduto = new ListaProduto();
            NavigationService.Navigate(new Uri("/ListaProduto.xaml", UriKind.Relative));

        }
        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}