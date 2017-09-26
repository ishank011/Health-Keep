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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Try1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dengue : Page
    {
        MapIcon[] list = new MapIcon[150];
        double[] cx = new double[150];
        double[] cy = new double[150];
        double[] clusx = new double[10];
        double[] clusy = new double[10];
        int[] clusno = new int[150];
        int p_num = -1,i1=0;
        private async void Init()
        {
            //this.button.Content = "adsdas";

            Windows.Storage.StorageFolder storageFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            //b1.Content = storageFolder.Path;

            string Filename = @"Assets\" + "dengue_data.csv";
            Windows.Storage.StorageFile file = await storageFolder.GetFileAsync(Filename);
            Stream Countries = await file.OpenStreamForReadAsync();
            //this.button.Content = "adsdas";

            using (var streamReader = new StreamReader(Countries))
            {
                //this.button.Content = "adsdas";
                p_num = int.Parse(streamReader.ReadLine());
                i1 = 0;
                while (streamReader.Peek() >= 0)
                {
                    cx[i1] = double.Parse(streamReader.ReadLine());
                    cy[i1] = double.Parse(streamReader.ReadLine());
                    clusno[i1] = new int();
                    i1++;
                }
                //streamReader.Dispose();

                //this.button.Content = "adsdas" + i1.ToString() + " " + p_num.ToString();

            }


        }
        private void back(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Try1.MainPage));
        }
        public Dengue()
        {
                
            this.InitializeComponent();
            //this.button.Content = "adsdas";

            double minx = 25.245945;
            double miny = 82.970921;
            double maxx = 25.272510;
            double maxy = 83.005367;

            cx[0] = 25.260303;
            cy[0] = 82.988921;
            cx[1] = 25.262784;
            cy[1] = 82.990738;
            cx[2] = 25.256473;
            cy[2] = 82.994535;
            cx[3] = 25.275161;
            cy[3] = 82.995045;
            cx[4] = 25.256266;
            cy[4] = 82.986947;
            cx[5] = 25.269633;
            cy[5] = 82.990429;
            cx[6] = 25.256032;
            cy[6] = 82.988521;
            cx[7] = 25.276008;
            cy[7] = 82.995413;
            cx[8] = 25.258668;
            cy[8] = 82.985772;
            cx[9] = 25.258865;
            cy[9] = 82.988938;
            cx[10] = 25.264223;
            cy[10] = 82.983650;
            cx[11] = 25.270052;
            cy[11] = 82.992178;
            cx[12] = 25.263365;
            cy[12] = 82.994971;
            cx[13] = 25.267428;
            cy[13] = 82.995190;
            cx[14] = 25.263603;
            cy[14] = 82.982369;
            cx[15] = 25.260320;
            cy[15] = 82.984743;
            cx[16] = 25.263073;
            cy[16] = 82.990014;
            cx[17] = 25.257070;
            cy[17] = 82.982895;
            cx[18] = 25.256412;
            cy[18] = 82.982783;
            cx[19] = 25.271059;
            cy[19] = 82.988052;
            cx[20] = 25.263960;
            cy[20] = 82.993291;
            cx[21] = 25.275462;
            cy[21] = 82.987596;
            cx[22] = 25.272291;
            cy[22] = 82.987995;
            cx[23] = 25.265082;
            cy[23] = 82.984223;
            cx[24] = 25.262784;
            cy[24] = 82.988574;
            cx[25] = 25.260814;
            cy[25] = 82.996227;
            cx[26] = 25.271059;
            cy[26] = 82.982690;
            cx[27] = 25.261873;
            cy[27] = 82.995747;
            cx[28] = 25.260793;
            cy[28] = 82.991099;
            cx[29] = 25.254918;
            cy[29] = 82.986817;
            cx[30] = 25.256955;
            cy[30] = 82.983440;
            cx[31] = 25.263040;
            cy[31] = 82.994799;
            cx[32] = 25.260032;
            cy[32] = 82.982515;
            cx[33] = 25.259699;
            cy[33] = 82.990077;
            cx[34] = 25.266026;
            cy[34] = 82.992043;
            cx[35] = 25.258508;
            cy[35] = 82.984626;
            cx[36] = 25.274428;
            cy[36] = 82.985094;
            cx[37] = 25.261760;
            cy[37] = 82.996658;
            cx[38] = 25.270074;
            cy[38] = 82.984425;
            cx[39] = 25.269442;
            cy[39] = 82.982589;
            cx[40] = 25.268758;
            cy[40] = 82.992524;
            cx[41] = 25.271929;
            cy[41] = 82.988709;
            cx[42] = 25.259653;
            cy[42] = 82.985499;
            cx[43] = 25.264241;
            cy[43] = 82.986849;
            cx[44] = 25.254457;
            cy[44] = 82.982713;
            cx[45] = 25.270609;
            cy[45] = 82.995969;
            cx[46] = 25.265482;
            cy[46] = 82.987032;
            cx[47] = 25.264302;
            cy[47] = 82.986736;
            cx[48] = 25.258582;
            cy[48] = 82.991964;
            cx[49] = 25.255516;
            cy[49] = 82.985304;
            cx[50] = 25.263852;
            cy[50] = 82.996594;
            cx[51] = 25.257325;
            cy[51] = 82.984027;
            cx[52] = 25.274849;
            cy[52] = 82.996662;
            cx[53] = 25.260757;
            cy[53] = 82.994647;
            cx[54] = 25.260942;
            cy[54] = 82.989544;
            cx[55] = 25.256558;
            cy[55] = 82.982859;
            cx[56] = 25.262677;
            cy[56] = 82.984739;
            cx[57] = 25.259835;
            cy[57] = 82.988389;
            cx[58] = 25.260928;
            cy[58] = 82.983916;
            cx[59] = 25.255149;
            cy[59] = 82.986426;
            cx[60] = 25.259373;
            cy[60] = 82.983472;
            cx[61] = 25.269419;
            cy[61] = 82.989942;
            cx[62] = 25.260268;
            cy[62] = 82.986972;
            cx[63] = 25.260816;
            cy[63] = 82.996420;
            cx[64] = 25.267176;
            cy[64] = 82.994373;
            cx[65] = 25.260463;
            cy[65] = 82.991777;
            cx[66] = 25.256775;
            cy[66] = 82.996323;
            cx[67] = 25.258301;
            cy[67] = 82.989271;
            cx[68] = 25.264367;
            cy[68] = 82.988239;
            cx[69] = 25.259280;
            cy[69] = 82.993756;
            cx[70] = 25.273862;
            cy[70] = 82.984722;
            cx[71] = 25.263264;
            cy[71] = 82.993432;
            cx[72] = 25.264421;
            cy[72] = 82.988877;
            cx[73] = 25.256025;
            cy[73] = 82.992349;
            cx[74] = 25.257703;
            cy[74] = 82.994054;
            cx[75] = 25.260074;
            cy[75] = 82.991864;
            cx[76] = 25.258813;
            cy[76] = 82.983488;
            cx[77] = 25.259167;
            cy[77] = 82.983492;
            cx[78] = 25.262630;
            cy[78] = 82.993122;
            cx[79] = 25.263950;
            cy[79] = 82.982919;
            cx[80] = 25.273441;
            cy[80] = 82.996842;
            cx[81] = 25.255989;
            cy[81] = 82.992757;
            cx[82] = 25.258148;
            cy[82] = 82.982566;
            cx[83] = 25.266947;
            cy[83] = 82.992110;
            cx[84] = 25.275946;
            cy[84] = 82.985260;
            cx[85] = 25.275253;
            cy[85] = 82.983984;
            cx[86] = 25.256907;
            cy[86] = 82.990570;
            cx[87] = 25.264549;
            cy[87] = 82.986853;
            cx[88] = 25.262128;
            cy[88] = 82.988637;
            cx[89] = 25.268382;
            cy[89] = 82.997342;
            cx[90] = 25.272036;
            cy[90] = 82.983861;
            cx[91] = 25.264499;
            cy[91] = 82.992007;
            cx[92] = 25.258926;
            cy[92] = 82.990278;
            cx[93] = 25.256914;
            cy[93] = 82.996491;
            cx[94] = 25.256640;
            cy[94] = 82.983598;
            cx[95] = 25.266962;
            cy[95] = 82.984163;
            cx[96] = 25.266023;
            cy[96] = 82.993830;
            cx[97] = 25.254643;
            cy[97] = 82.991642;
            cx[98] = 25.255021;
            cy[98] = 82.994128;
            cx[99] = 25.259689;
            cy[99] = 82.988053;
            cx[100] = 25.281782;
            cy[100] = 82.969950;
            cx[101] = 25.266504;
            cy[101] = 82.961843;
            cx[102] = 25.249947;
            cy[102] = 82.966946;
            cx[103] = 25.275501;
            cy[103] = 83.026977;
            cx[104] = 25.242735;
            cy[104] = 83.021818;
            cx[105] = 25.246235;
            cy[105] = 83.021466;
            cx[106] = 25.243372;
            cy[106] = 83.023107;

            Random random = new Random();
            int i, j;
            int noclus = 5, pop = 107;

            /*for (i = 0; i < pop; i++)
            {
                cx[i] = new double();
                cy[i] = new double();
                clusno[i] = new int();
                cx[i] = minx + (maxx - minx) * random.NextDouble();
                cy[i] = miny + (maxy - miny) * random.NextDouble();
            }*/


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
            Map.ZoomLevel = 14.7;

            m1 = dis(clusx[0], clusy[0], userx, usery);
            p = 0;
            for (i = 1; i < noclus; i++)
            {
                m2 = dis(clusx[i], clusy[i], userx, usery);
                if (m2 < m1)
                {
                    m1 = m2;
                    p = i;
                }
            }
            int flag = 0;
            if (lista[p].Count>10)
            {
                flag = 1;
            }

            if (flag == 1)
                ShowToast("\n\nBe precautious!\n\n", "\n\nThere is a high number of cases of Dengue near your location. Do take appropriate precautionary measures.\n");
        }
        int dis_num;
        /*protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            String parameters = (String)e.Parameter;
            dis_num = parameters[0] - '0';
        }*/

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
