using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TrailMakers.UI.News
{
    public class NewsPattern : ContentView
    {
        public NewsPattern()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "News Pattern Here" }
                }
            };
        }
    }
}