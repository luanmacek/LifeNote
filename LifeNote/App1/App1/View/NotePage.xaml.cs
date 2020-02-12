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
            points_slider.Value = note.Points;
        }

        private async void save_clicked(object sender, EventArgs e)
        {
            note.Date = date_label.Text;
            note.Content = content_editor.GetHtmlString();
            note.Points = points_slider.Value;
            await App.Database.SaveNoteAsync(note);
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1.0);

            points_slider.Value = newStep * 1.0;


           if(points_slider.Value == 1)
            {
                rateimage.Source = ImageSource.FromFile("rate1.png");
            }
            else if(points_slider.Value == 2)
            {
                rateimage.Source = ImageSource.FromFile("rate2.png");
            }
            else if (points_slider.Value == 3)
            {
                rateimage.Source = ImageSource.FromFile("rate3.png");
            }
            else if (points_slider.Value == 4)
            {
                rateimage.Source = ImageSource.FromFile("rate4.png");
            }
            else if (points_slider.Value == 5)
            {
                rateimage.Source = ImageSource.FromFile("rate5.png");
            }
        }
    }
}