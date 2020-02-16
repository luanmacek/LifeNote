using Android.Widget;
using App1.Model;
using App1.View;
using Syncfusion.SfRating.XForms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            rating.Value = note.Points;
        }

        private async void save_clicked(object sender, EventArgs e)
        {
            note.Date = date_label.Text;
            note.Content = content_editor.GetHtmlString();
            note.Points = rating.Value;
            await App.Database.SaveNoteAsync(note);
        }
    }
}