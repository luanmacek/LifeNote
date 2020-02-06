using Android.Widget;
using App1.Model;
using App1.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotePage 
    {
        Note note;
        public NotePage(Note Note)
        {           
            InitializeComponent();
            note = Note;
            date_label.Text = note.Date;
            content_editor.Text = note.Content;

            SaveB.OnClickCommand = new Command(async () =>
            {
                await DisplayAlert("Share", "Shared on Facebook!", "OK!");
            });
            RateB.OnClickCommand = new Command(async () =>
            {
                await DisplayAlert("Share", "Shared on Twitter!", "OK!");
            });
        }


        private async void FloatingActionButton_Clicked(object sender, EventArgs e)
        {
            note.Date = date_label.Text;
            note.Content = content_editor.Text;
            await App.Database.SaveNoteAsync(note);
            Toast.MakeText(Android.App.Application.Context, "Note has been succefuly saved.", ToastLength.Long).Show();
        }

    }
}