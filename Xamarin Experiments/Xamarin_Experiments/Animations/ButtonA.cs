using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin_Experiments.Animations
{
	public class ButtonA : ContentPage
	{
	    private Button myButton;

        public ButtonA()
		{
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
            await myButton.RotateTo(90, 250);
            await myButton.RotateTo(-90, 500);
            await myButton.ScaleTo(myButton.Scale += myButton.Scale/10);
            myButton.Clicked += OnButtonClicked;
        }
    }
}
