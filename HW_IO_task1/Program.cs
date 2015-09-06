using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_IO_task1
{
    class Program
    {
        static void WriteToFile(string filePath)
        {
            using (BinaryWriter fileWriter = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                try
                {
                    for (int i = 0; i < 256; i++)
                    {
                        fileWriter.Write((byte)i);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine(String.Format("You haven't enough right to write {0}", filePath));
                }
                catch (DirectoryNotFoundException)
                {
                    Console.WriteLine(String.Format("Directory doesn't exist {0}", filePath));
                }
                catch (IOException)
                {
                    Console.WriteLine(String.Format("IOException for file {0}", filePath));
                }
            }
        }

        static void ReadFromFile(string filePath)
        {
            try
            {
                using (BinaryReader fileReader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                {
                    while (fileReader.BaseStream.Position < fileReader.BaseStream.Length)
                    {
                        Console.WriteLine(fileReader.ReadByte());
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(String.Format("File {0} doesn't exist.", filePath));
            }
        }

        static void Main(string[] args)
        {
            WriteToFile(@".\text.txt");
            ReadFromFile(@".\text.txt");
            Console.ReadKey();           
        }
    }
}
