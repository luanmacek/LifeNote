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
        List<string> selectedActivities;
        ActivityViewModel viewmodel;
        public NotePage(Note Note)
        {           
            InitializeComponent();
            note = Note;
            date_label.Text = note.Date;
            content_editor.Text = note.Content;
            rating.Value = note.Points;
            selectedActivities = new List<string>();
            viewmodel = new ActivityViewModel();
            BindingContext = viewmodel;
        }

        private async void save_clicked(object sender, EventArgs e)
        {
            note.Date = date_label.Text;
            note.Content = content_editor.GetHtmlString();
            note.Points = int.Parse(rating.Value.ToString());
            note.Activities = selectedActivities;
            await App.Database.SaveNoteAsync(note);
            StatisticsPage.viewmodel.load_notes();
        }

        private void ClickToShowPopup_Clicked(object sender, EventArgs e)
        {
            popupLayout.Show();
        }


        private void activity_select(object sender, EventArgs e)
        {
            SfButton btn = sender as SfButton;
            foreach(Activity a in viewmodel.Activities)
            {
                if (btn.Text == a.Name)
                {
                    if (a.Selected)
                    {
                        btn.BackgroundColor = Color.LightSeaGreen;
                        a.Selected = false;
                        if (!selectedActivities.Contains(a.Name))
                        {
                            selectedActivities.Add(a.Name);
                        }
                    }
                    else
                    {
                        btn.BackgroundColor = Color.HotPink;
                        a.Selected = true;
                    }
                }
                
            }


        }
    }
}