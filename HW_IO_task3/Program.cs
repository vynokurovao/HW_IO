using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_IO_task3
{
    class Program
    {
        private const string Extension = ".gz";
        static void CompressAndCopy(string filePath)
        {
            FileInfo fileToCompress = new FileInfo(filePath);

            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + Extension))
                {
                    using (GZipStream compressionStream = new GZipStream(compressedFileStream,
                        CompressionMode.Compress))
                    {
                        originalFileStream.CopyTo(compressionStream);
                    }
                }
            }
        }


        public static void Decompress(string filePath, string newFileName)
        {
            FileInfo fileToDecompress = new FileInfo(filePath);
            using (FileStream originalFileStream = fileToDecompress.OpenRead())
            {
                using (FileStream decompressedFileStream = File.Create(newFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                    {
                        decompressionStream.CopyTo(decompressedFileStream);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            CompressAndCopy(@".\text.txt");
            Decompress(@".\text.txt.gz", "newFile.txt");
        }
    }
}
