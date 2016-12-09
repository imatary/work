using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace UMCWorkManager.App_Helpers
{
    public static class ImageUpload
    {
        // GET: Upload
        public const int AvatarStoredWidth = 100;  // ToDo - Change the size of the stored avatar image
        public const int AvatarStoredHeight = 100; // ToDo - Change the size of the stored avatar image
        public const int AvatarScreenWidth = 400;  // ToDo - Change the value of the width of the image on the screen
        

        private static readonly string[] _imageFileExtensions = { ".jpg", ".png", ".gif", ".jpeg" };
        public const string TempFolder = "/Temp";
        public const string MapTempFolder = "~" + ImageUpload.TempFolder;
        public const string AvatarPath = "/Avatars";
        public static bool IsImage(HttpPostedFileBase file)
        {
            if (file == null) return false;
            return file.ContentType.Contains("image") ||
                _imageFileExtensions.Any(item => file.FileName.EndsWith(item, StringComparison.OrdinalIgnoreCase));
        }

        public static string GetTempSavedFilePath(HttpPostedFileBase file)
        {
            // Define destination
            var serverPath = HttpContext.Current.Server.MapPath(TempFolder);
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }

            // Generate unique file name
            var fileName = Path.GetFileName(file.FileName);
            fileName = SaveTemporaryAvatarFileImage(file, serverPath, fileName);

            // Clean up old files after every save
            CleanUpTempFolder(1);
            return Path.Combine(TempFolder, fileName);
        }

        private static string SaveTemporaryAvatarFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            var img = new WebImage(file.InputStream);
            var ratio = img.Height / (double)img.Width;
            img.Resize(AvatarScreenWidth, (int)(AvatarScreenWidth * ratio));

            var fullFileName = Path.Combine(serverPath, fileName);
            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);
            return Path.GetFileName(img.FileName);
        }

        private static void CleanUpTempFolder(int hoursOld)
        {
            try
            {
                var currentUtcNow = DateTime.UtcNow;
                var serverPath = HttpContext.Current.Server.MapPath("/Temp");
                if (!Directory.Exists(serverPath)) return;
                var fileEntries = Directory.GetFiles(serverPath);
                foreach (var fileEntry in fileEntries)
                {
                    var fileCreationTime = System.IO.File.GetCreationTimeUtc(fileEntry);
                    var res = currentUtcNow - fileCreationTime;
                    if (res.TotalHours > hoursOld)
                    {
                        System.IO.File.Delete(fileEntry);
                    }
                }
            }
            catch
            {
                // Deliberately empty.
            }
        }
    }
}