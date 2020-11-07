using System;
using Xamarin.Forms;
using Notes.Models;
using SQLite;

namespace Notes
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
            listView.ItemsSource = await App.Database.GetNotesAsync();
        }
        async void pridat(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPageEntry
            {
                BindingContext = new Note()
            });
        }
        async void zobrazeni(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MainPageEntry
                {
                    BindingContext = e.SelectedItem as Note
                });
            }
        }
    }
}
