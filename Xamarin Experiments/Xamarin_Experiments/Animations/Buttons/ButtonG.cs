using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin
{
    public class ButtonG : ContentPage
    {
        private Label myLabel1;
        private Label myLabel2;
        private Grid myLayout;

        public ButtonG()
        {
            SizeChanged += OnPageSizeChanged;
            myLayout = new Grid();

            myLabel1 = new Label()
            {
                Text = "More",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 72,
                TextColor = Color.Red
            };


            myLabel2 = new Label()
            {
                Text = "Code",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = 72,
                TextColor = Color.Blue
            };

            myLayout.Children.Add(myLabel1);
            myLayout.Children.Add(myLabel2);

            Content = myLayout;
            AnimationLoop();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            if (Width > 0)
            {
                double fontSize = 0.3 * Width;
                myLabel1.FontSize = fontSize;
                myLabel2.FontSize = fontSize;
            }
        }

        async void AnimationLoop()
        {
            while (true)
            {
                await Task.WhenAll(myLabel1.FadeTo(0, 1000),
                myLabel2.FadeTo(1, 1000));
                await Task.WhenAll(myLabel1.FadeTo(1, 1000),
                myLabel2.FadeTo(0, 1000));
            }
        }


    }
}
