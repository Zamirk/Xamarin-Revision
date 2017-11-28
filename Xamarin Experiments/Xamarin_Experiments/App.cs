using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin_Experiments.MVVMTests.Alpha;

namespace Xamarin_Experiments
{
namespace Xamarin_Experiments
    {
        public partial class App : Application
        {
            public App()
            {
                MainPage = new NavigationPage(new MathView());
            }

            protected override void OnStart()
            {
                // Handle when your app starts
            }

            protected override void OnSleep()
            {
                // Handle when your app sleeps
            }

            protected override void OnResume()
            {
                // Handle when your app resumes
            }
        }
    }

}
