using App1.Model;
using App1.ViewModels;
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
        public static SideNoteViewModel viewmodel;
        public SideNoteMenuPage()
        {
            InitializeComponent();
            viewmodel = new SideNoteViewModel();
            BindingContext = viewmodel;
        }
        bool addtapped = false;
        private async void sidenote_Clicked(object sender, EventArgs e)
        {
            if (addtapped)
                return;

            addtapped = true;
            ImageButton button = (ImageButton)sender;
            button.IsEnabled = false;
            var classid = button.ClassId;
            SideNote sn = await App.Database.GetSideNoteById(int.Parse(classid));
            await Navigation.PushAsync(new SideNotePage(sn));           
            button.IsEnabled = true;
            addtapped = false;

        }
        bool tapped = false;

        async void label_tap(object sender, EventArgs args)
        {

            if (tapped)
                return;

            tapped = true;

            Label label = (Label)sender;
            var classid = label.ClassId;
            SideNote sn = await App.Database.GetSideNoteById(int.Parse(classid));
            await Navigation.PushAsync(new SideNotePage(sn));
            tapped = false;
        }


        private async void sidenoteadd_Clicked(object sender, EventArgs e)
        {
            SideNote sn = new SideNote();
            sn.Title = "";
            sn.Content = "";         
            await Navigation.PushAsync(new SideNotePage(sn));
            await App.Database.SaveSideNoteAsync(sn);
            viewmodel.sidenotes.Add(sn);
        }

    }
}