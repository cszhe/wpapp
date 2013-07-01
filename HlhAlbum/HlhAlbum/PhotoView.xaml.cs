using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace HlhAlbum
{
    public partial class PhotoView : PhoneApplicationPage
    {
        public PhotoView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            string type = this.NavigationContext.QueryString["q"];
            
            // change the title to query string.
            this.LayoutRoot.Children.Clear();

            //Initializing the Panorama Control and Assigning base values
            Panorama panoramactrl = new Panorama();
            panoramactrl.Title = type;

            string[] types = { "草原", "花卉", "建筑", "山景", "水景", "夜景" };
            int nResIdx = 0;
            for (int j = 0; j < types.Length; j++)
            {
                if (types[j].Equals(type))
                {
                    nResIdx = j;
                    break;
                }
            }

            for (int i = 1; i <= 3; i++)
            {
                //Initializing the Panorama Control Items
                PanoramaItem panoramaCtrlItem = new PanoramaItem();
                panoramaCtrlItem.Header = type + i.ToString();

                //Initializing Textblock to display some text
                Image img = new Image();
                string fname = "/Assets/" + nResIdx + "/" + i.ToString() + ".jpg";
                img.Source = new BitmapImage(new Uri(fname, UriKind.Relative));
                panoramaCtrlItem.Content = img;

                panoramactrl.Items.Add(panoramaCtrlItem);
            }

            this.LayoutRoot.Children.Add(panoramactrl);
            
        }
    }
}