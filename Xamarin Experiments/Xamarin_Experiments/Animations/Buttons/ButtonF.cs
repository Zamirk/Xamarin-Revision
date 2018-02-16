using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin
{
    public class ButtonF : ContentPage
    {
        private StackLayout myLayout;
        private Label myLabel;
        bool keepAnimation5Running = false;

        public ButtonF()
        {
            myLayout = new StackLayout();

            Button myButton1 = new Button();
            myButton1.Text = "Animation 1 (Scale)";
            myButton1.Clicked += OnButton1Clicked;

            Button myButton2 = new Button();
            myButton2.Text = "Animation 2 (Repeated)";
            myButton2.Clicked += OnButton2Clicked;

            Button myButton3 = new Button();
            myButton3.Text = "Stop Animation 2";
            myButton3.Clicked += OnStop2Clicked;

            Button myButton4 = new Button();
            myButton4.Text = "Animation 3 (Scale up &amp; dpwm)";
            myButton4.Clicked += OnButton3Clicked;

            Button myButton5 = new Button();
            myButton5.Text = "Animation 4 (Scale &amp; Rotate)";
            myButton5.Clicked += OnButton4Clicked;

            myLabel = new Label();
            myLabel.Text = "WaitLabel";
            myLabel.WidthRequest = 100;

            Button myButton8 = new Button();
            myButton8.Text = "Animation 6 (Color)";
            myButton8.Clicked += OnButton6Clicked;

            myLayout.Children.Add(myButton1);
            myLayout.Children.Add(myButton2);
            myLayout.Children.Add(myButton3);
            myLayout.Children.Add(myButton4);
            myLayout.Children.Add(myButton5);
            myLayout.Children.Add(myButton8);
            Content = myLayout;
        }

        void OnButton1Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            Animation animation = new Animation(
                (double value) => { button.Scale = value; }, // callback
                1, // start
                5, // end
                Easing.Linear, // easing
                () => { Debug.WriteLine("finished"); } // finished (but doesn't fire in this configuration)
            );
            animation.Commit(
                this, // owner
                "Animation1", // name
                16, // rate (but has no effect here)
                1000, // length (in milliseconds)
                Easing.Linear,
                (double finalValue, bool wasCancelled) =>
                {
                    Debug.WriteLine("finished: {0} {1}", finalValue, wasCancelled);
                    button.Scale = 1;
                }, // finished
                () =>
                {
                    Debug.WriteLine("repeat");
                    return false;
                } // repeat
            );
        }

        void OnButton2Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            Animation animation = new Animation(v => button.Scale = v, 1, 5);
            animation.Commit(this, "Animation2", 16, 1000, Easing.Linear,
                (v, c) => button.Scale = 1,
                () => true);
        }

        void OnStop2Clicked(object sender, EventArgs args)
        {
            this.AbortAnimation("Animation2");
        }

        void OnButton3Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            // Create parent animation object.
            Animation parentAnimation = new Animation();
            // Create "up" animation and add to parent.
            Animation upAnimation = new Animation(
                v => button.Scale = v,
                1, 5, Easing.SpringIn,
                () => Debug.WriteLine("up finished"));
            parentAnimation.Add(0, 0.5, upAnimation);
            // Create "down" animation and add to parent.
            Animation downAnimation = new Animation(
                v => button.Scale = v,
                5, 1, Easing.SpringOut,
                () => Debug.WriteLine("down finished"));
            parentAnimation.Insert(0.5, 1, downAnimation);
            // Commit parent animation.
            parentAnimation.Commit(
                this, "Animation3", 16, 5000, null,
                (v, c) => Debug.WriteLine("parent finished: {0} {1}", v, c));
        }

        void OnButton4Clicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            new Animation
            {
                {0, 0.5, new Animation(v => button.Scale = v, 1, 5)},
                {0.25, 0.75, new Animation(v => button.Rotation = v, 0, 360)},
                {0.5, 1, new Animation(v => button.Scale = v, 5, 1)}
            }.Commit(this, "Animation4", 16, 5000);
        }

        void OnButton5Clicked(object sender, EventArgs args)
        {
            Animation animation =
                new Animation(v => myLabel.Text = new string('.', (int)v), 0, 10);
            animation.Commit(this, "Animation5", 16, 3000, null,
                (v, cancelled) => myLabel.Text = "",
                () => keepAnimation5Running);
            keepAnimation5Running = true;
        }

        void OnTurnOffButtonClicked(object sender, EventArgs args)
        {
            keepAnimation5Running = false;
        }

        void OnButton6Clicked(object sender, EventArgs args)
        {
            new Animation(callback: v => BackgroundColor = Color.FromHsla(v, 1, 0.5),
                start: 0,
                end: 1).Commit(owner: this,
                name: "Animation6",
                length: 5000,
                finished: (v, c) => BackgroundColor = Color.Default);
        }
    }
}
