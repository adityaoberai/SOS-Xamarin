using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Threading;
using XamarinSOSLHDGPS.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace XamarinSOSLHDGPS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                CancellationTokenSource cts;
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, cts.Token);

                if (location != null)
                {
                    var coord = $"{location.Latitude},{location.Longitude}";
                    Coordinates data = new Coordinates { coordinates = coord };

                    var client = new HttpClient();

                    var json = JsonConvert.SerializeObject(data);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync("<ENTER AZURE FUNCTION URL>", content);

                    string result = await response.Content.ReadAsStringAsync();

                    if (result.Equals(""))
                    {
                        await DisplayAlert("Response", "Error Occured", "OK");
                    }
                    else
                    {
                        await DisplayAlert("Response", "SMS Sent", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Location", "Not Found", "OK");
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Response", $"Error Occured:\n\n{ex}", "OK");
            }
        }
    }
}
