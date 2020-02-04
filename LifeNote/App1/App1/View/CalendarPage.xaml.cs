using App1.Model;
using Syncfusion.SfCalendar.XForms;
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
    public partial class CalendarPage : ContentPage
    {
        [Obsolete]
        public CalendarPage()
        {
            InitializeComponent();
            calendar.ViewMode = ViewMode.MonthView;
            calendar.OnCalendarTapped += Calendar_OnCalendarTapped;
            calendar.ClearSelection();
        }

        [Obsolete]
        async void Calendar_OnCalendarTapped(object sender, CalendarTappedEventArgs e)
        {
            SfCalendar calendar = (sender as SfCalendar);
            DateTime date = e.datetime;
            Note oldnote = await App.Database.GetNoteAsync(date.ToString("MM/dd/yyyy"));
            if (oldnote == null)
            {
                Note newnote = new Note();
                newnote.Title = "";
                newnote.Date = date.ToString("MM/dd/yyyy");
                newnote.Content = "";
                MainPage.NewNote(newnote);

            }
            else
            {
                MainPage.OldNote(oldnote);
            }
        }
    }
}