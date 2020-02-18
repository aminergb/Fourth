using Common.Api.Dtos;
using Newtonsoft.Json;
using Storm.Mvvm;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using TD.Api.Dtos;
using TestFourthplace.View;
using Xamarin.Forms;

namespace TestFourthplace.ViewModel
{
    class ViewModelLogin : ViewModelBase
    {
        public ICommand GoToNextCommand { get; }

        private string _UserName;
        private string _PassWord;
        private HttpMethod post;

        public string UserName
        {
            get => _UserName;
            set => SetProperty(ref _UserName, value);
        }
        public string PassWord { get => _PassWord; set => SetProperty(ref _PassWord, value); }

        public ViewModelLogin()

        {

            GoToNextCommand = new Command(GoToNextAction);

        }



        private async void GoToNextAction()

        { 
            //creation d'un objet loginrequest
            HttpResponseMessage reponse;
            var api = new ApiClient();
            LoginRequest loginreq = new LoginRequest();
            loginreq.Password = PassWord;
            loginreq.Email = UserName;
            reponse = await api.Execute(HttpMethod.Post,"https://td-api.julienmialon.com/auth/login", loginreq);
            Console.WriteLine(PassWord);
            Response ReadResponse = await api.ReadFromResponse<Response>(reponse);
            //LoginResult LogInToken = await api.ReadFromResponse<LoginResult>(reponse);
            if (ReadResponse.IsSuccess)
            {
                //string content= await reponse.Content.ReadAsStringAsync();

                //prendre le data dans l'objet response en forme de string 
                LoginResult LogInToken = await api.ReadFromResponse<LoginResult>(reponse);
                //Response<string> result_data = JsonConvert.DeserializeObject<Response<string>>(content);
                //prendre les status  dans l'objet loginresult
                //LoginResult result_status = JsonConvert.DeserializeObject<LoginResult>(content);
                //string g = result_data.Data;
                //Console.WriteLine(DataLogin);
                Application.Current.Properties["AccessToken"] = LogInToken.AccessToken;
                Application.Current.Properties["ExpiresIn"] = LogInToken.ExpiresIn;
                Application.Current.Properties["RefreshToken"] = LogInToken.RefreshToken;
                await NavigationService.PushAsync(new hello());

            }
            else

            {

                MessagingCenter.Send(this, "LoginAlert", "Echec");



            }

          

        }
         

        }
    }
