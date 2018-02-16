using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin
{
    public class ButtonH : ContentPage
    {
        private JiggleButton myButton;

        public ButtonH()
        {
            myButton = new JiggleButton()
            {
                FontSize = 72,
                Text = "Text",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            ContentView myView = new ContentView()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            myView.Content = myButton;
            Content = myView;
        }

        public class JiggleButton: Button 
            {
            bool isJiggling;

            public JiggleButton()
            {
                Clicked += async (sender, args) =>
                {
                    if (isJiggling)
                    {
                        return;
                    }
                    else
                    {
                        isJiggling = true;
                        await this.RotateTo(15, 1000, new Easing(t =>
                            Math.Sin(Math.PI * t) *
                            Math.Sin(Math.PI * 20 * t)));
                        isJiggling = false;
                    }
                };
            }
        }
    }
}