using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin_Experiments.Animations
{
    public class ButtonE : ContentPage
    {
        private Button myButton;

        public ButtonE()
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
            // Swing down from lower-left corner.
            myButton.AnchorX = 0;
            myButton.AnchorY = 1;

            await myButton.RotateTo(90, 3000,
                new Easing(t => 1 - Math.Cos(10 * Math.PI * t) * Math.Exp(-5 * t)));

            // Drop to the bottom of the screen.
            await myButton.TranslateTo(0, (Height - myButton.Height) / 2 - myButton.Width,
                1000, Easing.BounceOut);

            // Prepare AnchorX and AnchorY for next rotation.
            myButton.AnchorX = 1;
            myButton.AnchorY = 0;

            // Compensate for the change in AnchorX and AnchorY.
            myButton.TranslationX -= myButton.Width - myButton.Height;
            myButton.TranslationY += myButton.Width + myButton.Height;

            // Fall over.
            await myButton.RotateTo(180, 1000, Easing.BounceOut);

            // Fade out while ascending to the top of the screen.
            await Task.WhenAll
            (
                myButton.FadeTo(0, 4000),
                myButton.TranslateTo(0, -Height, 5000, Easing.CubicIn)
            );

            // After 1 second, return the Button to normal.
            await Task.Delay(1000);
            myButton.TranslationX = 0;
            myButton.TranslationY = 0;
            myButton.Rotation = 0;
            myButton.Opacity = 1;
            myButton.Clicked += OnButtonClicked;        }
    }
}
