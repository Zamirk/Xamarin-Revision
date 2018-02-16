using System;
using Xamarin.Forms;

/*
 * Xamarin Forms buttons animations
 * 
 * 
 */


namespace Xamarin
{
	public class ButtonA : ContentPage
	{
	    private Button myButton;

        public ButtonA()
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
            await myButton.RotateTo(90, 250);
            await myButton.RotateTo(-90, 500);
            await myButton.ScaleTo(myButton.Scale += myButton.Scale/10);
            myButton.Clicked += OnButtonClicked;
        }
    }
}
