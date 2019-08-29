using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BinHexEdit
{
    public sealed class IconConverter : IValueConverter
    {
        public IconConverter()
        {
        }

        public static IconConverter Default { get; } = new IconConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }

            Project project = (Project)value;

            string iconPath = System.IO.Path.Combine(project.DirectoryName, project.IconPath + ".ico");

            if (!System.IO.File.Exists(iconPath))
            {
                return null;
            }

            var image = new BitmapImage(new Uri(iconPath));

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
