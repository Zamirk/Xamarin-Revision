﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RAT.MvvmTests
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    namespace Xamarin_Experiments.MVVMTests.Alpha
    {
        public class ViewModelBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
            {
                if (Object.Equals(storage, value)) return false;

                storage = value;
                OnPropertyChanged(propertyName);
                return true;
            }

            protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}