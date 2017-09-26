using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Devices.Geolocation;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Try1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //GeolocationAccessStatus accessStatus;
        public MainPage()
        {
            this.InitializeComponent();
            //do1();
            int n = 3;
            int x = 1000 / n;
            String[] s= { "Cholera", "Malaria", "Dengue" };
            for (int i = 0; i < n; i++)
            {
                Button newBtn = new Button();

                newBtn.Content =s[i];
                int r = (i + 1) * x;
                newBtn.Name = i.ToString() + "b";
                newBtn.Width = 150;
                newBtn.Height = 50;
                //newBtn.Margin.= r.ToString();// + "200,0,0";
                //newBtn.Margin.Left = r;
                Thickness margin;// = MyControl.Margin;
                margin.Left = r;
                margin.Top = 100;
                newBtn.Margin = margin;
                //FontFamily z = new FontFamily("Ryo Gothic PlusN");
                //newBtn.FontFamily = z;
                newBtn.FontSize = 18;
                newBtn.Click += move;// "move";
                this.grid.Children.Add(newBtn);
                if(i==0)
                {
                    margin.Left = 500;
                    margin.Top = 100;
                    newBtn.Margin = margin;
                }
                else if (i == 1)
                {
                    margin.Left = 700;
                    margin.Top = 100;
                    newBtn.Margin = margin;
                }
                else if (i == 2)
                {
                    margin.Left = 900;
                    margin.Top = 100;
                    newBtn.Margin = margin;
                }
            }

        }
        private void move(object sender, RoutedEventArgs e)
        {
            Button b1 = (Button)sender;
            string x = b1.Name[0]+"";
            if(x=="0")
                this.Frame.Navigate(typeof(Try1.Cholera));
            else if(x=="1")
                this.Frame.Navigate(typeof(Try1.Malaria));
            else
                this.Frame.Navigate(typeof(Try1.Dengue));
        }
    }
}
