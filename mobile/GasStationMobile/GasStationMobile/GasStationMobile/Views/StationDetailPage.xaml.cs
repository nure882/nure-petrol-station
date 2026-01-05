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
    public partial class StationDetailPage : ContentPage
    {
        public Station Station { get; set; }
        public StationDetailPage()
        {
        }

        public StationDetailPage(int stationId)
        {
            InitializeComponent();
            LoadStationAsync(stationId);
        }

        private async void LoadStationAsync(int stationId)
        {
            var _stationService = DependencyService.Get<IStationService>();
            Station station = await _stationService.GetStation(stationId);
            Station = station;
            BindingContext = Station;
        }
    }
}