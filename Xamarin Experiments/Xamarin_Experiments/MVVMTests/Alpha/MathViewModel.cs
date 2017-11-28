using RAT.MvvmTests.Xamarin_Experiments.MVVMTests.Alpha;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Xamarin_Experiments.MVVMTests.Alpha
{
    class MathViewModel : ViewModelBase
    {
        double multiplicand, multiplier, product;


        public MathViewModel()
        {

        }
        public double Multiplicand
        {
            set
            {
                if (SetProperty(ref multiplicand, value))
                {
                    UpdateProduct();
                }
            }
            get { return multiplicand; }
        }

        public double Multiplier
        {
            set
            {
                if (SetProperty(ref multiplier, value))
                {
                    UpdateProduct();
                }
            }
            get { return multiplier; }
        }

        public double Product
        {
            protected set
            {
                if (SetProperty(ref product, value))
                {
                    UpdateProduct();
                }
            }
            get { return product; }
        }

        void UpdateProduct()
        {
            Product = Multiplicand * Multiplier;
        }
    }
}
