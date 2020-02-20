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
        ActivityViewModel viewmodel;
        bool newnote;
        public NotePage(Note Note, bool Newnote)
        {           
            InitializeComponent();
            newnote = Newnote;
            note = Note;
            date_label.Text = note.Date;
            content_editor.Text = note.Content;
            rating.Value = note.Points;
            viewmodel = new ActivityViewModel(newnote, note);
            BindingContext = viewmodel;
        }

        private void save_clicked(object sender, EventArgs e)
        {
            note.Date = date_label.Text;
            note.Content = content_editor.GetHtmlString();
            note.Points = int.Parse(rating.Value.ToString());
            foreach (Activity a in viewmodel.SelectedItems)
            {
                if (!note.Activities.Contains(a))
                    note.Activities.Add(a);
            }
            App.Database.SaveNoteAsync(note);
            StatisticsPage.viewmodel.load_notes();
            if (!newnote)
            {
                viewmodel.load(note.Id);
            }
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            popupLayout.Show();
        }

        private void SfChipGroup_SelectionChanged(object sender, Syncfusion.Buttons.XForms.SfChip.SelectionChangedEventArgs e)
        {
            if (!viewmodel.SelectedItems.Contains(e.AddedItem as Activity) && e.AddedItem != null && e.RemovedItem != null)
            {
                viewmodel.SelectedItems.Add(e.AddedItem as Activity);
            }
        }
    }
}