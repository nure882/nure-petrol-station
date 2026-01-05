using GasStationMobile.Interfaces;
using GasStationMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GasStationMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StationsPage : ContentPage
    {
        public StationsPage()
        {
            InitializeComponent();
            LoadStationsAsync();
        }

        private async void LoadStationsAsync()
        {
            var _stationService = DependencyService.Get<IStationService>();
            List<Station> stations = await _stationService.GetStations("", "");
            stationsListView.ItemsSource = stations;
        }

        private async void OpenButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.CommandParameter is int stationId)
                {
                    StationDetailPage detailPage = new StationDetailPage(Convert.ToInt32(stationId));
                    await Navigation.PushAsync(detailPage);
                }
            }
        }
    }
}