using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace Xamarin_Experiments.Animations
{
    public class ButtonG : ContentPage
    {
        private Button myButton;

        public ButtonG()
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
            myButton.Rotation = 0;
            myButton.RotateTo(360, 2000);
            await myButton.ScaleTo(5, 1000);
            await myButton.ScaleTo(1, 1000);
            myButton.Clicked += OnButtonClicked;        }
    }
}
