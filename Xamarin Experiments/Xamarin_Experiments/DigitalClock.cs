using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Xamarin_Experiments
{
    class DigitalClock : ContentPage
    {
        /*
         * • A simple clock app
         * • Displays the current time
         * • Time moves arround the screen every second
         */

        Random random = new Random();
        Label myLabel;

        public DigitalClock()
        {
            AbsoluteLayout myLayout = new AbsoluteLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand, 
            };

            myLabel = new Label();
            AbsoluteLayout.SetLayoutFlags(myLabel, AbsoluteLayoutFlags.PositionProportional);
            myLayout.Children.Add(myLabel);
            Content = myLayout;

            InfiniteLoop();
        }

        async void InfiniteLoop()
        {
            while (true)
            {
                myLabel.Text = DateTime.Now.ToString("T");
                myLabel.FontSize = random.Next(12, 49);
                AbsoluteLayout.SetLayoutBounds(myLabel, new Rectangle(random.NextDouble(),
                    random.NextDouble(),
                    AbsoluteLayout.AutoSize,
                    AbsoluteLayout.AutoSize));
                await Task.Delay(1000);
            }
        }
    }
}
