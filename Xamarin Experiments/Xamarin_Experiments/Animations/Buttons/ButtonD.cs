using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Xamarin
{
    public class ButtonD : ContentPage
    {
        private Button myButton;

        public ButtonD()
        {
            myButton = new Button()
            {
                FontSize = 72,
                Text = "Text",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center, 
            };

            myButton.Clicked += OnButtonClicked;

            ContentView myView = new ContentView()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            myView.Content = myButton;
            Content = myView;
        }

        async void OnButtonClicked(object sender, EventArgs args)
        {
            myButton.Clicked -= OnButtonClicked;
            await myButton.RotateTo(90, 250, Easing.SinOut);
            await myButton.RotateTo(-90, 500, Easing.SinInOut);
            await myButton.RotateTo(0, 250, Easing.SinIn);
            myButton.Clicked += OnButtonClicked;        }
    }
}
