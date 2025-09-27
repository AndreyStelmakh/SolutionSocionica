﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public abstract class ExtendedNotify : INotifyPropertyChanged
    {
        protected void RaisePropertyChanged<T>(Expression<Func<T>> action)
        {
            RaisePropertyChanged(GetPropertyName(action));

        }

        private static string GetPropertyName<T>(Expression<Func<T>> action)
        {
            var expression = (MemberExpression)action.Body;

            return expression.Member.Name;

        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
