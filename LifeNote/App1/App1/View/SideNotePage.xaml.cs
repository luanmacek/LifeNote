using Android.Widget;
using App1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SideNotePage
    {
        SideNote sn;
        public SideNotePage(SideNote Sn)
        {
            InitializeComponent();
            sn = Sn;
            title_editor.Text = sn.Title;
            content_editor.Text = sn.Content;
        }

        private async void content_editor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            await App.Database.SaveSideNoteAsync(sn);
            Toast.MakeText(Android.App.Application.Context, "Side note"+ sn.Title + " has been succefuly saved.", ToastLength.Long).Show();
        }
    }
}