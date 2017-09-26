using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.Devices.Geolocation;
using System.IO;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Try1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Malaria : Page
    {
        MapIcon[] list = new MapIcon[50];
        double[] cx = new double[50];
        double[] cy = new double[50];
        double[] clusx = new double[10];
        double[] clusy = new double[10];
        int[] clusno = new int[50];

        public Malaria()
        {

            this.InitializeComponent();
            double minx = 25.216945;
            double miny = 82.870921;
            double maxx = 25.347000;
            double maxy = 83.105367;                        

            Random random = new Random();
            int i, j;
            int noclus = 9, pop = 50;
            
            for (i = 0; i < pop; i++)
            {
                cx[i] = new double();
                cy[i] = new double();
                clusno[i] = new int();
                cx[i] = minx + (maxx - minx) * random.NextDouble();
                cy[i] = miny + (maxy - miny) * random.NextDouble();
            }
            

            for (i = 0; i < noclus; i++)
            {
                clusx[i] = new double();
                clusy[i] = new double();
                clusx[i] = minx + (maxx - minx) * random.NextDouble();
                clusy[i] = miny + (maxy - miny) * random.NextDouble();
            }

            int iter = 0, maxiter = 5, p;
            double m1, m2, sx, sy;
            List<int>[] lista = new List<int>[10];
            while (iter < maxiter)
            {
                for (i = 0; i < noclus; i++)
                {
                    lista[i] = new List<int>();
                }
                for (i = 0; i < pop; i++)
                {
                    m1 = dis(cx[i], cy[i], clusx[0], clusy[0]);
                    p = 0;
                    for (j = 1; j < noclus; j++)
                    {
                        m2 = dis(cx[i], cy[i], clusx[j], clusy[j]);
                        if (m2 < m1)
                        {
                            m1 = m2;
                            p = j;
                        }
                    }
                    lista[p].Add(i);
                    clusno[i] = p;
                }
                for (i = 0; i < noclus; i++)
                {
                    sx = 0;
                    sy = 0;
                    for (j = 0; j < lista[i].Count; j++)
                    {
                        sx += cx[lista[i][j]];
                        sy += cy[lista[i][j]];
                    }
                    clusx[i] = sx / lista[i].Count;
                    clusy[i] = sy / lista[i].Count;
                }

                iter++;
            }

            for (i = 0; i < pop; i++)
            {
                // Create a MapIcon.
                BasicGeoposition snPosition = new BasicGeoposition() { Latitude = cx[i], Longitude = cy[i] };
                Geopoint snPoint = new Geopoint(snPosition);
                list[i] = new MapIcon();
                list[i].NormalizedAnchorPoint = new Point(0.5, 1.0);
                list[i].Location = snPoint;
                //list[i].Title = "Point" + clusno[i].ToString();
                list[i].ZIndex = 0;
                if (clusno[i] == 0)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/red.png"));
                else if (clusno[i] == 1)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/green.png"));
                else if (clusno[i] == 2)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/yellow.png"));
                else if (clusno[i] == 3)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/blue.png"));
                else if (clusno[i] == 4)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/orange.png"));
                else if (clusno[i] == 5)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/cyan.png"));
                else if (clusno[i] == 6)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/maroon.png"));
                else if (clusno[i] == 7)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/purple.png"));
                else if (clusno[i] == 8)
                    list[i].Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/pink.png"));

                list[i].CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;

                // Add the MapIcon to the map.
                Map.MapElements.Add(list[i]);
            }

            double userx = 25.262078;
            double usery = 82.993473;

            BasicGeoposition cPosition = new BasicGeoposition() { Latitude = userx, Longitude = usery };
            Geopoint cPoint = new Geopoint(cPosition);
            MapIcon user = new MapIcon();
            user.NormalizedAnchorPoint = new Point(0.5, 1.0);
            user.ZIndex = 0;
            user.Location = cPoint;
            user.Image = RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/star.png"));
            user.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;
            Map.MapElements.Add(user);

            Map.Center = cPoint;
            Map.ZoomLevel = 12.5;

            m1 = dis(cx[0], cy[0], userx, usery);
            p = 0;
            for(i=1; i<noclus; i++)
            {
                m2 = dis(cx[i], cy[i], userx, usery);
                if (m2 < m1)
                {
                    m1 = m2;
                    p = i;
                }
            }
            int flag = 0;
            if(lista[p].Count>20)
            {
                flag = 1;
            }

            if (flag == 1)
                ShowToast("\n\nBe precautious!\n\n", "\n\nThere is a high number of cases of Malaria near your location. Do take appropriate precautionary measures.\n");
        }
        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Try1.MainPage));
        }

        private static void ShowToast(string title, string content)
        {
            XmlDocument toastXml = new XmlDocument();
            string xml = $@"
  <toast activationType='foreground'>
  <visual>
    <binding template='ToastGeneric'>
     <text>{title}</text>
     <text>{content}</text>
    </binding>
   </visual>
  </toast>";
            toastXml.LoadXml(xml);
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        private double dis(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        }
    }
}
