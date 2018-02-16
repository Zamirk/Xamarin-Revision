using RAT.MvvmTests.Xamarin_Experiments.MVVMTests.Alpha;

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

        //Maths logic
        void UpdateProduct()
        {
            Product = Multiplicand * Multiplier;
        }
    }
}
 