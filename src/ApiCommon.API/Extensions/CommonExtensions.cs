using System.Text.RegularExpressions;

namespace ApiCommon.API.Extensions
{
    public static class CommonExtensions
    {
        public static bool IsAnyStringNullOrEmpty(this object obj)
            => obj.GetType().GetProperties()
                .Where(pi => pi.PropertyType == typeof(string))
                .Select(pi => (string?)pi.GetValue(obj))
                .Any(string.IsNullOrEmpty);


        public static bool IsImage(this IFormFile postedFile, int imageMinimumBytes = 512,
            int imageMaximumBytes = 5 * 1024 * 1024)
        {
            //  Check the image mime types
            if (postedFile.ContentType.ToLower() != "image/jpg" &&
                postedFile.ContentType.ToLower() != "image/jpeg" &&
                postedFile.ContentType.ToLower() != "image/pjpeg" &&
                postedFile.ContentType.ToLower() != "image/gif" &&
                postedFile.ContentType.ToLower() != "image/x-png" &&
                postedFile.ContentType.ToLower() != "image/png")
            {
                return false;
            }

            //  Check the image extension
            if (Path.GetExtension(postedFile.FileName).ToLower() != ".jpg"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".png"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".gif"
                && Path.GetExtension(postedFile.FileName).ToLower() != ".jpeg")
            {
                return false;
            }

            //  Attempt to read the file and check the first bytes
            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                    return false;
                if (postedFile.Length < imageMinimumBytes)
                    return false;
                if (postedFile.Length > imageMaximumBytes)
                    return false;

                var buffer = new byte[imageMinimumBytes];
                postedFile.OpenReadStream().Read(buffer, 0, imageMinimumBytes);
                var content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content,
                        @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                        RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            // Try to instantiate new Bitmap, if .NET will throw exception we can assume that it's not a valid image
            // try
            // {
            //     using (var bitmap = new System.Drawing.Bitmap(postedFile.OpenReadStream()))
            //     {
            //     }
            // }
            // catch (Exception)
            // {
            //     return false;
            // }
            // finally
            // {
            //     postedFile.OpenReadStream().Position = 0;
            // }

            return true;
        }
    }
}
