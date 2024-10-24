using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace DBMS_Final_Project.control.converter
{
    public static class imageLinkConverter
    {
        /// <summary>
        /// Nhập vào đường dẫn tương đối, trả về đường dẫn tuyệt đối.
        /// </summary>
        /// <param name="path">Đường dẫn tương đối.</param>
        /// <returns></returns>
        public static object Convert(string path)
        {
            try
            {
                if (path != null)
                {
                    //ABSOLUTE
                    if (path.Length > 0 && path[0] == System.IO.Path.DirectorySeparatorChar
                        || path.Length > 1 && path[1] == System.IO.Path.VolumeSeparatorChar)
                        return new BitmapImage(new Uri(path));

                    //RELATIVE
                    return new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory().Substring(0, System.IO.Directory.GetCurrentDirectory().IndexOf("bin")) + path));
                }
                return string.Empty;
            }
            catch (Exception)
            {
                return new BitmapImage();
            }

        }

        public static object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}