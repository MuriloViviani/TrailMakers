﻿using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin Forms!" }
                }
            };
        }
    }
}