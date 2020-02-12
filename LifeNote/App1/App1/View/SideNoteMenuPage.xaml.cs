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
            foreach(SideNote s in sidenotes_list)
            {
            }
        }

        private async void sidenote_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string classid = button.ClassId;
            foreach (SideNote sn in sidenotes_list)
            {
                if(sn.Id == int.Parse(classid))
                {
                    await Navigation.PushAsync(new SideNotePage(sn));
                }
            }
            
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