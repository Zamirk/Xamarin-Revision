using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace Xamarin_Experiments.Animations
{
    class SpinningVortex : ContentPage
    {
        private AbsoluteLayout myLayout;
        const int numSpokes = 24;
        BoxView[] boxViews = new BoxView[numSpokes];

        public SpinningVortex()
        {
            myLayout = new AbsoluteLayout();
            myLayout.HorizontalOptions = LayoutOptions.Center;
            myLayout.VerticalOptions = LayoutOptions.Center;
            SizeChanged += OnPageSizeChanged;
            BackgroundColor = Color.White;

            Content = myLayout;

            // Create all the BoxView elements.
            for (int i = 0; i < numSpokes; i++)
            {
                BoxView boxView = new BoxView
                {
                    Color = Color.Black
                };
                boxViews[i] = boxView;
                myLayout.Children.Add(boxView);
            }
            AnimationLoop();
        }

        void OnPageSizeChanged(object sender, EventArgs args)
        {
            // Set AbsoluteLayout to a square dimension.
            double dimension = Math.Min(this.Width, this.Height);
            myLayout.WidthRequest = dimension;
            myLayout.HeightRequest = dimension;

            // Find the center and a size for the BoxView.
            Point center = new Point(dimension / 2, dimension / 2);
            Size boxViewSize = new Size(dimension / 2, 3);
            for (int i = 0; i < numSpokes; i++)
            {
                // Find an angle for each spoke.
                double degrees = i * 360 / numSpokes;
                double radians = Math.PI * degrees / 180;

                // Find the point of the center of each BoxView spoke.
                Point boxViewCenter = new Point(center.X + boxViewSize.Width / 2 * Math.Cos(radians),
                  center.Y + boxViewSize.Width / 2 * Math.Sin(radians));

                // Find the upper-left corner of the BoxView and position it.
                Point boxViewOrigin = boxViewCenter - boxViewSize * 0.5;
                AbsoluteLayout.SetLayoutBounds(boxViews[i],
                 new Rectangle(boxViewOrigin, boxViewSize));

                // Rotate the BoxView around its center.
                boxViews[i].Rotation = degrees;
            }
        }

        async
        void AnimationLoop
         ()
        {
            await Task.Delay(3000);
            uint count = 3;
            await myLayout.RotateTo(360 * count, 3000 * count);

            // Prepare for creating Task objects.
            List<Task<bool>> taskList = new List<Task<bool>>(numSpokes + 1);
            while (true)
            {
                foreach (BoxView boxView in boxViews)
                {
                    // Task to rotate each spoke.
                    taskList.Add(boxView.RelRotateTo(360, 3000));
                }

                // Task to rotate the whole configuration.
                taskList.Add(myLayout.RelRotateTo(360, 3000));

                // Run all the animations; continue in 3 seconds.
                await Task.WhenAll(taskList);

                taskList.Clear();
            }
        }
    }
}