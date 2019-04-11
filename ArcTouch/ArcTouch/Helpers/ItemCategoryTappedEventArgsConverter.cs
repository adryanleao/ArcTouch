using System;
using System.Globalization;
using Xamarin.Forms;

namespace ArcTouch.Helpers
{
    public class ItemCategoryTappedEventArgsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var itemTappedEventArgs = value as ItemTappedEventArgs;
            if (itemTappedEventArgs == null)
                throw new ArgumentException("Expected value to be of type ItemTappedEventArgs", nameof(value));

            //itemTappedEventArgs.Item
            return GetPropertyValue(itemTappedEventArgs.Item, "id").ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;

        public static object GetPropertyValue(object obj, string name)
        {
            return obj == null ? null : obj.GetType().GetProperty(name).GetValue(obj, null);
        }
    }
}
