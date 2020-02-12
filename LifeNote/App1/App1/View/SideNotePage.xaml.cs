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
        SideNote sidenote;
        public SideNotePage(SideNote Sn)
        {
            sidenote = Sn;
            InitializeComponent();        
            title_editor.Text = Sn.Title;
            content_editor.Text = Sn.Content;
        }

        private async void content_editor_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            sidenote.Title = title_editor.Text;
            sidenote.Content = content_editor.Text;
            await App.Database.SaveSideNoteAsync(sidenote);
        }

        private async void delsidenote_Clicked(object sender, EventArgs e)
        {
            await App.Database.DeleteSideNoteAsync(sidenote);
            await Navigation.PushAsync(new CalendarPage());
        }
    }
}