using System;
using System.IO;

namespace E04_CopyBinaryFile
{
    public class CopyBinaryFile
    {
        private const string path = "../../Files/";

        public static void Main()
        {
            Console.WriteLine($"Copy file '{path}image.jpg'");
            Console.WriteLine($"To file '{path}imageCopy.jpg'");

            var sourceFilePath = $"{path}image.jpg";
            var copyFilePath = $"{path}imageCopy.jpg";

            using (var sourceFile = new FileStream(sourceFilePath, FileMode.Open))
            {
                using (var copyFile = new FileStream(copyFilePath, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        int readBytes = sourceFile.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0) break;

                        copyFile.Write(buffer, 0, readBytes);
                        //Console.WriteLine($"{(double)sourceFile.Position / sourceFile.Length:P}");
                    }
                }
            }
        }
    }
}
