using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MergeCsvFiles
{

    /// <summary>
    /// This class walks us iteratively through the directory paths
    /// </summary>
    public class DirectoryWalker
    {
        private List<string> filesLstInDir = new List<string>();

        /// <summary>
        /// Iterates re through the directory paths
        /// </summary>
        /// <param name="path">Path to directory</param>
        public List<string> Walk(string path)
        {

            var list = Directory.GetDirectories(path);

            if (list == null)
            {
                return new List<string>();
            }

            foreach (var dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    //Recursive step
                    Walk(dirpath);
                    Console.WriteLine("Dir:" + dirpath);
                }
            }

            var fileList = Directory.GetFiles(path);
            

            if (fileList.Length != 0)
            {
                foreach(var file in fileList)
                filesLstInDir.Add(file);
            }

            return filesLstInDir;
        }
    }
}
