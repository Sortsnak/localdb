using localdb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using SQLite;


namespace localdb
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            RegistrationListView.ItemsSource = await App.Database.GetPeopleAsync();
        }



        async void OnButtonClicked(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(Email.Text) && !string.IsNullOrWhiteSpace(Password.Text))
            {
                await App.Database.SavePersonAsync(new Credentials
                {
                    Email = Email.Text,
                    Password = Password.Text,

                });

                Email.Text = Password.Text = string.Empty;
                RegistrationListView.ItemsSource = await App.Database.GetPeopleAsync();

            }
        }
    }  
}