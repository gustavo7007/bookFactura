using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression
using System.Linq;
using System.Web;

namespace FacturacionCloud.Clases
{
    public class Util
    {
        public void comprimir()
        {
            FileInfo fileToBeGZipped = new FileInfo(@"c:\gzip\logfile.txt");
            FileInfo gzipFileName = new FileInfo(string.Concat(fileToBeGZipped.FullName, ".gz"));

            using (FileStream fileToBeZippedAsStream = fileToBeGZipped.OpenRead())
            {
                using (FileStream gzipTargetAsStream = gzipFileName.Create())
                {
                    using (GZipStream gzipStream = new GZipStream(gzipTargetAsStream, CompressionMode.Compress))
                    {
                        try
                        {
                            fileToBeZippedAsStream.CopyTo(gzipStream);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
        public void descomprimir()
        {
            using (FileStream fileToDecompressAsStream = gzipFileName.OpenRead())
            {
                string decompressedFileName = @"c:\gzip\decompressed.txt";
                using (FileStream decompressedStream = File.Create(decompressedFileName))
                {
                    using (GZipStream decompressionStream = new GZipStream(fileToDecompressAsStream, CompressionMode.Decompress))
                    {
                        try
                        {
                            decompressionStream.CopyTo(decompressedStream);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}