using GasStationMobile.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: Dependency(typeof(ApiService))]
[assembly: Dependency(typeof(AuthService))]
[assembly: Dependency(typeof(CouponService))]
[assembly: Dependency(typeof(UserService))]
[assembly: Dependency(typeof(StationService))]