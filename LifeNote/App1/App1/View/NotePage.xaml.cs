using Android.Widget;
using App1.Model;
using App1.View;
using App1.ViewModels;
using Syncfusion.SfRating.XForms;
using Syncfusion.XForms.Buttons;
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
        public ActivityViewModel viewmodel;
        public NotePage(Note Note, bool newnote)
        {           
            InitializeComponent();
            note = Note;
            date_label.Text = note.Date;
            content_editor.Text = note.Content;
            rating.Value = note.Points;
            viewmodel = new ActivityViewModel(note,newnote);
            BindingContext = viewmodel;
        }

        private async void save_clicked(object sender, EventArgs e)
        {
            note.Date = date_label.Text;
            note.Content = content_editor.GetHtmlString();
            note.Points = int.Parse(rating.Value.ToString());          
            await App.Database.SaveNoteAsync(note);
            viewmodel.saveActivities();
            //viewmodel.load(note.Id);
            StatisticsPage.viewmodel.load();
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            popupLayout.Show();
        }

        private void CheckBox_StateChanged(object sender, StateChangedEventArgs e) {
            StatisticsPage.viewmodel.load();
        }
    }
}