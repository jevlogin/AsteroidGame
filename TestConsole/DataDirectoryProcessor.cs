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
        //  СТЕК
        public static int GetTotalLinesCountStack(string DirectoryPath)
        {
            var directory = new DirectoryInfo(DirectoryPath);

            Stack<DirectoryInfo> directory_to_process = new Stack<DirectoryInfo>();
            directory_to_process.Push(directory);


            var total_lines = 0;
            while (directory_to_process.Count > 0)
            {
                var process_dir = directory_to_process.Pop();

                foreach (var sub_dir in process_dir.EnumerateDirectories())
                {
                    directory_to_process.Push(sub_dir);
                }

                foreach (var txt in process_dir.EnumerateFiles("*.txt"))
                {
                    total_lines += GetLinesCount(txt);
                }
            }

            return total_lines;
        }

        //  ОЧЕРЕДЬ
        public static int GetTotalLinesCountQueue(string DirectoryPath)
        {
            var directory = new DirectoryInfo(DirectoryPath);

            Queue<DirectoryInfo> directory_to_process = new Queue<DirectoryInfo>();
            directory_to_process.Enqueue(directory);


            var total_lines = 0;
            while (directory_to_process.Count > 0)
            {
                var process_dir = directory_to_process.Dequeue();

                foreach (var sub_dir in process_dir.EnumerateDirectories())
                {
                    directory_to_process.Enqueue(sub_dir);
                }

                foreach (var txt in process_dir.EnumerateFiles("*.txt"))
                {
                    total_lines += GetLinesCount(txt);
                }
            }

            return total_lines;
        }

        private static int GetLinesCount(FileInfo file)
        {
            var lines_count = 0;
            foreach (var line in GetLines(file))
            {
                lines_count++;
            }
            return lines_count;
        }

        private static IEnumerable<string> GetLines(FileInfo file)
        {
            using (var reader = file.OpenText())
            {
                while (!reader.EndOfStream)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
