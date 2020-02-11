using App1.Model;
using Syncfusion.XForms.Buttons;
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
    public partial class SideNoteMenuPage : ContentPage
    {
        List<SideNote> sidenotes_list;
        public SideNoteMenuPage()
        {
            InitializeComponent();
            start();
        }

        async void start()
        {
            sidenotes_list = await App.Database.GetSideNotesAsync();
            if(sidenotes_list.Count() != 0)
            {
                foreach (SideNote sn in sidenotes_list)
                {
                    Button btn = new Button();
                    //btn.BackgroundColor = Color.Transparent;
                    //btn.BorderColor = Color.Transparent;
                    btn.Text = sn.Title;
                    btn.HeightRequest = 100;
                    btn.WidthRequest = 50;
                    //btn.ImageSource = "sidenotemenu.png";
                    btn.HorizontalOptions = LayoutOptions.Center;
                    btn.VerticalOptions = LayoutOptions.Center;
                    btn.Clicked += delegate (object sender, EventArgs e) { sidenote_Clicked(sender, e, sn); };
                    layout.Children.Add(btn);
                }
            }
            SfButton addbtn = new SfButton();
            addbtn.Clicked += sidenoteadd_Clicked;
            addbtn.ImageSource = "sidenote_plus.png";
            addbtn.ShowIcon = true;
            addbtn.CornerRadius = 40;
            addbtn.WidthRequest = 50;
            addbtn.HeightRequest = 50;
            addbtn.HorizontalOptions = LayoutOptions.Center;
            addbtn.VerticalOptions = LayoutOptions.Center;
            layout.Children.Add(addbtn);
        }

        private async void sidenote_Clicked(object sender, EventArgs e, SideNote Sn)
        {
            await Navigation.PushAsync(new SideNotePage(Sn));
        }

        private async void sidenoteadd_Clicked(object sender, EventArgs e)
        {
            SideNote sn = new SideNote();
            sn.Title = "";
            sn.Content = "";
            await Navigation.PushAsync(new SideNotePage(sn));
        }
    }
}