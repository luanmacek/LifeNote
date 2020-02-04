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
    public partial class MainPage : ContentPage
    {
        public static ContentView MainView;
        [Obsolete]
        public void ClickTap1(object sender, EventArgs e)
        {
            var page = new CalendarPage();
            MainView.Content = page.Content;
        }

        public void ClickTap2(object sender, EventArgs e)
        {
            var page = new SideNotePage();
            MainView.Content = page.Content;

        }

        public void ClickTap3(object sender, EventArgs e)
        {
            var page = new StatisticsPage();
            MainView.Content = page.Content;

        }

        public void ClickTap4(object sender, EventArgs e)
        {
            var page = new SettingsPage();
            MainView.Content = page.Content;
        }
        public static void OldNote(Note n)
        {
            var page = new NotePage(n);
            MainView.Content = page.Content;
        }
        public static void NewNote(Note n)
        {
            var page = new NotePage(n);
            MainView.Content = page.Content;
        }
        [Obsolete]
        public MainPage()
        {
            InitializeComponent();
            MainView = new ContentView();
            grid.Children.Add(MainView);
            MainView.SetValue(Grid.RowProperty, 0);
            MainView.IsVisible = true;
            MainView.BackgroundColor = Color.White;
            var page = new CalendarPage();
            MainView.Content = page.Content;
        }
    }
}