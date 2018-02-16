using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Xamarin_Experiments.MVVMTests.Alpha
{
    /*
     * • Maths application
     * • 2 Sliders and a result
     * • Changing the sliders allows you to multiply various numbers together
     */
    class MathView : ContentPage
    {
        public MathView()
        {
            MathViewModel myViewModel = new MathViewModel();
            BindingContext = myViewModel;

            StackLayout myStackLayout = new StackLayout() { VerticalOptions = LayoutOptions.StartAndExpand };

            Slider mySliderOne = new Slider();
            Slider mySliderTwo = new Slider();

            Label myLabel = new Label()
            {
                Text = "Maths!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            myStackLayout.Children.Add(mySliderOne);
            myStackLayout.Children.Add(mySliderTwo);
            myStackLayout.Children.Add(myLabel);

            mySliderOne.SetBinding(Slider.ValueProperty, "Multiplicand");
            mySliderTwo.SetBinding(Slider.ValueProperty, "Multiplier");
            myLabel.SetBinding(Label.TextProperty, "Product");

            Content = myStackLayout;
        }
    }
}
