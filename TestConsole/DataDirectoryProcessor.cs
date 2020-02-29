using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestConsole
{
    static class DataDirectoryProcessor
    {
        public static int GetTotalLinesCount(string DirectoryPath)
        {
            var directory = new DirectoryInfo(DirectoryPath);

            Stack<DirectoryInfo> directory_to_process = new Stack<DirectoryInfo>();
            directory_to_process.Push(directory);

            return 0;
        }
    }
}
