using Storm.Mvvm;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Common.Api.Dtos;
using TD.Api.Dtos;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace TestFourthplace.ViewModel
{
    class ViewModelLieux: ViewModelBase
    {

        //public ICommand GoToDetailCommand { get; }
        private List<PlaceItemSummary> _ListPlaces;
        public string _ReadResponse;
        public List<PlaceItemSummary> ListPlaces { get => _ListPlaces; set => SetProperty(ref _ListPlaces, value); }
        public string ReadResponse { get => _ReadResponse; set => SetProperty(ref _ReadResponse, value); }
        public ViewModelLieux() {
            ListPlaces = new List<PlaceItemSummary>();
            DisplayListPlaces();
            //GoToDetailCommand = new Command(GoToDetailPlace);
           
        }
        public async void GoToDetailPlace() 
        {

        }
        
        public async Task DisplayListPlaces()
        {
            var api = new ApiClient();
            PlaceItemSummary placeme = new PlaceItemSummary();
            placeme.Title = "j'essaye de vivre";
            placeme.Latitude = 2035658;
            placeme.Id = 19;
            placeme.Longitude = 56423;
            placeme.ImageId = 756296;
            placeme.Description = "Il ETAIT UN JOUR , DEUX JOURS , TROIS JOURS .... ";


            // HttpResponseMessage PostResponse = await  api.Execute(HttpMethod.Post,placeme);
            //Response PResponse = await api.ReadFromResponse<Response>(PostResponse);
            //if (PResponse.IsSuccess)
            // {

           


        HttpResponseMessage GetResponse = await api.Execute(HttpMethod.Get, "https://td-api.julienmialon.com/places",null);
            Response GetResponseStatus = await api.ReadFromResponse<Response>(GetResponse);
            //ReadResponse = GetResponseStatus.ErrorCode.ToString();
            placeme.Title = GetResponseStatus.ErrorMessage;
           
            
            List<PlaceItemSummary> GetListPlaces = await api.ReadFromResponse<List<PlaceItemSummary>>(GetResponse);
           
            foreach (var Place in GetListPlaces)
                
            {
               
                ListPlaces.Add(Place);
            }

           

            
            
            
            
           // var RequestGeo = new GeolocationRequest(GeolocationAccuracy.Medium);
            //var location = await Geolocation.GetLocationAsync(RequestGeo);
            //var location = await Geolocation.GetLastKnownLocationAsync();
            //var position = new Location(location.Latitude, location.Longitude);
            //var options = new MapLaunchOptions { Name = "Microsoft Building 25" };

            //await Map.OpenAsync(position, options);
            //cree une requete GET qui permet de recuperer les places et de les stocker dans l'objet placeitem 
            
            //pour chaque place on crée un objet place et on stock les info dans place puis on affiche sur xaml
        }
    }
}
