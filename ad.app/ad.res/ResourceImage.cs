using System;
using System.Windows.Media.Imaging;

namespace ad.res
{
    public static class ResourceImage
    {
        #region Get path Icon
        /**
        * <summary>
            * Gets the icon image from reource assembly.
        * </summary>
*/
        public static BitmapImage GetIcon(string name)
        {
            //AD.Res.Images.icon_TagWallLayers_32x32.png
            // Create the resource reader stream.
            var pt = $"{ResourceAssembly.GetNamespace}Images.{name}";
            var stream = ResourceAssembly.GetAssembly.GetManifestResourceStream(pt);
            var image = new BitmapImage();

            // Construct and return image.

            Uri uri = new Uri(pt, UriKind.RelativeOrAbsolute);
            image.BeginInit();
            // image.UriSource = uri;
            image.StreamSource = stream;
            image.EndInit();
            // Return constructed BitmapImage.
            return image;
        }
        #endregion
    }
}
