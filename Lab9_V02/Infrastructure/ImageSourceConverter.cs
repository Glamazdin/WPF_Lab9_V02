using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace Lab9_V02.Infrastructure
{
    class ImageSourceConverter : IValueConverter
    {
        string root = Directory.GetCurrentDirectory();
        string ImageDirectory => Path.Combine(root, "images");
        public object Convert(object value, Type targetType,
                            object parameter, CultureInfo culture)
        {
            return Path.Combine(ImageDirectory, (string)value);
        }
        public object ConvertBack(object value, Type targetType,
                            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

