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
        public static SideNoteViewModel viewmodel;
        public SideNoteMenuPage()
        {
            InitializeComponent();
            viewmodel = new SideNoteViewModel();
            BindingContext = viewmodel;
        }
        private async void sidenote_Clicked(object sender, EventArgs e)
        {
            ImageButton button = (ImageButton)sender;
            var classid = button.ClassId;
            SideNote sn = await App.Database.GetSideNoteById(int.Parse(classid));
            await Navigation.PushAsync(new SideNotePage(sn));
            
        }
        async void label_tap(object sender, EventArgs args)
        {
            Label label = (Label)sender;
            var classid = label.ClassId;
            SideNote sn = await App.Database.GetSideNoteById(int.Parse(classid));
            await Navigation.PushAsync(new SideNotePage(sn));
        }

        private async void sidenoteadd_Clicked(object sender, EventArgs e)
        {
            SideNote sn = new SideNote();
            sn.Title = "";
            sn.Content = "";
            viewmodel.sidenotes.Add(sn);
            await Navigation.PushAsync(new SideNotePage(sn));          
        }

    }
}