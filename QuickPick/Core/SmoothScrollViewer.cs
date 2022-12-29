using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;

namespace QuickPick.Core
{
    public class SmoothScrollViewer : System.Windows.Controls.ScrollViewer
    {
        public SmoothScrollViewer()
        {
            Loaded += ScrollViewer_Loaded;
        }

        private void ScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollInfo = new ScrollInfoAdapter(ScrollInfo);
        }
    }
}
