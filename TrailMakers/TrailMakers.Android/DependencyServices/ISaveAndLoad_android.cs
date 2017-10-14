using System;
using System.Threading.Tasks;
using TrailMakers.Interface;
using System.IO;
using Xamarin.Forms;
using TrailMakers.Droid.DependencyServices;

[assembly: Dependency(typeof(ISaveAndLoad_Android))]
namespace TrailMakers.Droid.DependencyServices
{
    public class ISaveAndLoad_Android : ISaveAndLoad
    {
        #region INTERFACE_IMPLEMENTATION
        public bool CheckFile(string filename)
        {
            return File.Exists(PathToFile(filename));
        }

        public async Task<string> LoadTextAsync(string filename)
        {
            var path = PathToFile(filename);
            using (StreamReader sr = File.OpenText(path))
                return await sr.ReadToEndAsync();
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
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            return System.IO.Path.Combine(docsPath, filename);
        }
        #endregion
    }
}