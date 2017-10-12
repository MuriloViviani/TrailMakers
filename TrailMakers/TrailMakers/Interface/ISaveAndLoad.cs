using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailMakers.Interface
{
    public interface ISaveAndLoad
    {
        /// <summary>
        /// Save a text in a file
        /// </summary>
        /// <param name="fileName">Name for the file</param>
        /// <param name="text"></param>
        /// <returns></returns>
        Task SaveTextAsync(string fileName, string text);
        /// <summary>
        /// Loads the text that is in a File
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <returns></returns>
        Task<string> LoadTextAsync(string filename);
        /// <summary>
        /// Check if a file exists
        /// </summary>
        /// <param name="filename">Name of the file</param>
        /// <returns>return True if the file exists and False if not</returns>
        bool CheckFile(string filename);

    }
}
