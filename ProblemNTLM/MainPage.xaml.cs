using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NtlmHttpHandler;
using Xamarin.Forms;

namespace ProblemNTLM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }



        async void btnStart_Clicked(System.Object sender, System.EventArgs e)
        {
            

            var handler = NtlmHttpHandlerFactory.Create();

            handler.Credentials = new NetworkCredential(login.Text, password.Text, domain.Text); 

            var httpClient = new HttpClient(handler);

            var response = await httpClient.GetAsync(url.Text);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                result.Text = json;
            }
            
        }
    }
}
