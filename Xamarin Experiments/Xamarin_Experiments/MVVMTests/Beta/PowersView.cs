using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin_Experiments
{
    class PowersView: ContentPage
    {
        public PowersView()
        {
            //Binding viewmodel
            PowersViewModel myViewModel = new PowersViewModel(3);
            BindingContext = myViewModel;

            //Layout
            StackLayout myStackLayout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                Spacing = 0
            };

            Label myLabelOne = new Label() {
                FontSize = 100,
                Text = "Test"
            };

            Label myLabelTwo = new Label() {
                FontSize = 25,
                Text = "Test"
            };

            Label myLabelThree = new Label() {
                FontSize = 50,
                Text = "Test"
            };

            //Binding
            myLabelOne.SetBinding(Label.TextProperty, "BaseValue");
            myLabelTwo.SetBinding(Label.TextProperty, "Exponent");
            myLabelThree.SetBinding(Label.TextProperty, "Power");

            Button myLeftButton = new Button()
            {
                BackgroundColor = Color.Green,
                VerticalOptions = LayoutOptions.Center
            };

            Button myRightButton = new Button()
            {
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.Center
            };

            //myLeftButton.Command.Execute("");
            myLeftButton.SetBinding(Button.CommandProperty, new Binding("DecreaseExponentCommand"));
            myRightButton.SetBinding(Button.CommandProperty, new Binding("IncreaseExponentCommand"));

            StackLayout aaa = new StackLayout() {};
            aaa.Orientation = StackOrientation.Horizontal;
            aaa.Children.Add(myLabelOne);
            aaa.Children.Add(myLabelTwo);
            aaa.Children.Add(myLabelThree);
            myStackLayout.Children.Add(aaa);
            myStackLayout.Children.Add(myLeftButton);
            myStackLayout.Children.Add(myRightButton);

            Content = myStackLayout;
        }
    }
}
