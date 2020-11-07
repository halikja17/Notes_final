using System;
using Xamarin.Forms;
using Notes.Models;

namespace Notes
{
    public partial class MainPageEntry : ContentPage
    {
        public MainPageEntry()
        {
            InitializeComponent();
        }
        async void ulozit(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            note.Date = DateTime.UtcNow;
            await App.Database.SaveNoteAsync(note);
            await Navigation.PopAsync();
        }
        async void smazat(object sender, EventArgs e)
        {
            var note = (Note)BindingContext;
            await App.Database.DeleteNoteAsync(note);
            await Navigation.PopAsync();
        }
    }
}
