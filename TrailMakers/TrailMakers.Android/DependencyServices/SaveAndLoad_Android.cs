using System;
using System.IO;
using System.Threading.Tasks;
using Android.Graphics;
using TrailMakers.Business.Interface;
using TrailMakers.Droid.DependencyServices;
using Xamarin.Forms;
using System.Net;

[assembly: Dependency(typeof(SaveAndLoad_Android))]
namespace TrailMakers.Droid.DependencyServices
{
    public class SaveAndLoad_Android : ISaveAndLoad
    {
        #region INTERFACE_IMPLEMENTATION
        public bool CheckFile(string filename, bool image)
        {
            if (!image)
                return File.Exists(PathToFile(filename));
            else
                return File.Exists(PathToImage(filename));
        }

        private string PathToImage(string filename)
        {
            var directory = System.IO.Path.Combine
                (Environment.GetFolderPath(Environment.SpecialFolder.Personal), "img");

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            return System.IO.Path.Combine(directory, filename);
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            var path = PathToFile(filename);
            try
            {
                using (StreamReader sr = File.OpenText(path))
                    return await sr.ReadToEndAsync();
            }
            catch (Exception e)
            {
                return "";
            }
        }

        public async Task SaveTextAsync(string fileName, string text)
        {
            var path = PathToFile(fileName);
            using (StreamWriter sw = File.CreateText(path))
                await sw.WriteAsync(text);
        }
        #endregion

        #region CLASS_METHODS
        /// <summary>
        /// Return the path to a file
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <returns></returns>
        private string PathToFile(string filename)
        {
            filename = filename + ".txt";
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(docsPath, filename);
        }

        public void SaveImage(string filename, string imageURL)
        {
            var path = PathToImage(filename);
            if (!CheckFile(path, true))
            {
                Bitmap imageBitmap = null;
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(imageURL);
                    if (imageBytes != null && imageBytes.Length > 0)
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }

                using (var stream = new FileStream(path, FileMode.CreateNew))
                    imageBitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);

                imageBitmap.Dispose();
            }
        }

        public Bitmap LoadImage(string filename)
        {
            var path = PathToImage(filename);
            Bitmap bitmap = BitmapFactory.DecodeFile(path);

            return bitmap;
        }
        #endregion
    }
}