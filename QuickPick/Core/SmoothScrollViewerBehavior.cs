using System.Reflection;
using System.Windows.Controls.Primitives;
using System.Windows.Interactivity;

namespace QuickPick.Core
{
    public class SmoothScrollViewerBehavior : Behavior<System.Windows.Controls.ScrollViewer>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Loaded += ScrollViewerLoaded;
        }

        private void ScrollViewerLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var property = AssociatedObject.GetType().GetProperty("ScrollInfo", BindingFlags.NonPublic | BindingFlags.Instance);
            property.SetValue(AssociatedObject, new ScrollInfoAdapter((IScrollInfo)property.GetValue(AssociatedObject)));
        }
    }
}
