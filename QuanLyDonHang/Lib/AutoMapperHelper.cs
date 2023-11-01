﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyDonHang.Lib
{
    public static class AutoMapperHelper
    {
        public static TDestination Update<TSource, TDestination>(TSource source, TDestination destination) where TSource : class where TDestination : class
        {
            var typeDestination = typeof(TDestination);
            var typeSource = typeof(TSource);
            ParameterExpression parameter = Expression.Parameter(typeSource, "p");
            if (source == null)
            {
                throw new Exception("TSource is null");
            }
            if (destination == null)
            {
                throw new Exception("TDestination is null");
            }
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TSource));
            foreach (PropertyDescriptor property in properties)
            {
                MemberExpression memberAccess = null;
                memberAccess = MemberExpression.Property
                        (memberAccess ?? (parameter as Expression), property.Name);


                var value = typeSource.GetProperty(property.Name).GetValue(source);
                if (typeDestination.GetProperty(property.Name) != null && typeDestination.GetProperty(property.Name).PropertyType == typeSource.GetProperty(property.Name).PropertyType)
                    typeDestination.GetProperty(property.Name).SetValue(destination, value);
            }

            return destination;
        }
    }
}
