using QuickPick.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace QuickPick.Core
{
    public class ScrollViewerBehavior : DependencyObject
    {
        public static ScrollArgs GetAutoScroll(DependencyObject obj)
        {
            return (ScrollArgs)obj.GetValue(AutoScroll);
        }

        public static void SetAutoScroll(DependencyObject obj, ScrollArgs value)
        {
            obj.SetValue(AutoScroll, value);
        }

        public static readonly DependencyProperty AutoScroll =
            DependencyProperty.RegisterAttached("AutoScroll", typeof(ScrollArgs), typeof(ScrollViewerBehavior), new PropertyMetadata(new ScrollArgs(), (o, e) =>
            {
                var scrollViewer = o as ScrollViewer;
                if (scrollViewer == null)
                {
                    return;
                }
                if ((e.NewValue as ScrollArgs).Direction == "right")
                {
                    if ((e.NewValue as ScrollArgs).Offset > scrollViewer.ExtentWidth)
                        scrollViewer.ScrollToRightEnd();
                    else
                    {
                        if ((e.NewValue as ScrollArgs).Speed > 1)
                        {
                            for (int i = 0; i < (e.NewValue as ScrollArgs).Offset; i++)
                                scrollViewer.LineRight();
                            SetAutoScroll(o, new ScrollArgs());
                        }
                        else
                        {
                            for (int i = 0; i < (e.NewValue as ScrollArgs).Offset / 10; i++)
                                scrollViewer.LineRight();
                            SetAutoScroll(o, new ScrollArgs());
                        }
                    }
                }
                else if ((e.NewValue as ScrollArgs).Direction == "left")
                {
                    if ((e.NewValue as ScrollArgs).Offset > scrollViewer.ExtentWidth)
                        scrollViewer.ScrollToLeftEnd();
                    else
                    {
                        if ((e.NewValue as ScrollArgs).Speed > 1)
                        {
                            for (int i = 0; i < (e.NewValue as ScrollArgs).Offset; i++)
                                scrollViewer.LineLeft();
                            SetAutoScroll(o, new ScrollArgs());
                        }
                        else
                        {
                            for (int i = 0; i < (e.NewValue as ScrollArgs).Offset / 10; i++)
                                scrollViewer.LineLeft();
                            SetAutoScroll(o, new ScrollArgs());
                        }
                    }
                }
            }));
    }
}
