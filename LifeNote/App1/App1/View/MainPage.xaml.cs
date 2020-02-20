using App1.Model;
using App1.Styles;
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
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        bool darkmode = false;
        public void Handle_ModeChange(object sender, EventArgs e)
        {
            ICollection<ResourceDictionary> mergedDictionaries = Application.Current.Resources.MergedDictionaries;
            if (mergedDictionaries != null)
            {
                mergedDictionaries.Clear();
                if (darkmode == false)
                {
                    mergedDictionaries.Add(new DarkTheme());
                    darkmode = true;
                }
                else
                {
                    mergedDictionaries.Add(new LightTheme());
                    darkmode = false;
                }

            }
            SetIcon();
        }

        void SetIcon()
        {
            if (!darkmode)
            {
                this.FindByName<ToolbarItem>("ModeMenuItem").IconImageSource = "moon.png";
            }
            else
            {

                this.FindByName<ToolbarItem>("ModeMenuItem").IconImageSource = "sun.png";
            }
        }
    }
}