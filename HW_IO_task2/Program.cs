using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_IO_task2
{
    class Program
    {
        static void ReplaceInAllFiles(List<FileInfo> filesInfo, string etalon, string newValue)
        {
            foreach (FileInfo fileInfo in filesInfo)
            {
                string content = File.ReadAllText(fileInfo.FullName);
                content = content.Replace(etalon, newValue);
                File.WriteAllText(fileInfo.FullName, content);
            }
        }

        static List<FileInfo> FindFilesWhichContain(DirectoryInfo directory, string etalon)
        {
            List<FileInfo> resultFilesInfo = new List<FileInfo>();
            FileInfo[] filesInfo = new FileInfo[0];

            try
            {
                filesInfo = directory.GetFiles("*.txt", SearchOption.AllDirectories);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(String.Format("You have no enough rights to search in {0}.", directory.FullName));
            }

            foreach (FileInfo fileInfo in filesInfo)
            {
                string content = File.ReadAllText(fileInfo.FullName);
                if (content.Contains(etalon))
                {
                    resultFilesInfo.Add(fileInfo);
                }
            }

            return resultFilesInfo;
        }

        static void Main(string[] args)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@".\HW_IO");
            List<FileInfo> filesInfo = FindFilesWhichContain(dirInfo, "world");

            foreach (FileInfo fileInfo in filesInfo)
            {
                Console.WriteLine(fileInfo.FullName);
            }

            ReplaceInAllFiles(filesInfo, "using", "world");
            Console.ReadKey();
        }
    }
}