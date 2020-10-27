﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace Lab9_V02.Infrastructure
{
    public class ImageSourceConverter2:IValueConverter
    {
        string root = Directory.GetCurrentDirectory();
        string ImageDirectory => Path.Combine(root, "images");
        public object Convert(object value, Type targetType,
                            object parameter, CultureInfo culture)
        {
            var image = new BitmapImage();
           
            using (var stream = File.OpenRead(Path.Combine(ImageDirectory, (string)value)))
            { 
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
            }
            return image;
        }
        public object ConvertBack(object value, Type targetType,
                            object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
