using Android.Widget;
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
    public partial class SideNotePage
    {
        SideNote sidenote;
        public SideNotePage(SideNote Sn)
        {         
            InitializeComponent();
            sidenote = Sn;
            title_editor.Text = Sn.Title;
            content_editor.Text = Sn.Content;
        }


        private async void delete_sidenote(object sender, EventArgs e)
        {
            foreach (SideNote sn in SideNoteMenuPage.viewmodel.sidenotes)
            {
                if (sn.Id == sidenote.Id)
                {
                    SideNoteMenuPage.viewmodel.sidenotes.Remove(sn);
                    break;
                }
            }
            await App.Database.DeleteSideNoteAsync(sidenote);
            await Navigation.PopAsync();

        }

        private async void save_sidenote(object sender, EventArgs e)
        {
                sidenote.Title = title_editor.Text;
                sidenote.Content = content_editor.GetHtmlString();
                foreach (SideNote sn in SideNoteMenuPage.viewmodel.sidenotes)
                {
                    if (sn.Id == sidenote.Id)
                    {
                        sn.Title = title_editor.Text;
                        sn.Content = content_editor.Text;
                    }
                }
                await App.Database.SaveSideNoteAsync(sidenote);
        }
    }
}