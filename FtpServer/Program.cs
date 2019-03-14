using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FtpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Create Object Instance */
            ftp ftpClient = new ftp(@"ftp://127.0.0.1/", "inpeg", "inpe1234");

            /* Upload a File */
            ftpClient.upload("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

            /* Download a File */
            ftpClient.download("etc/test.txt", @"C:\Users\metastruct\Desktop\test.txt");

            /* Delete a File */
            ftpClient.delete("etc/test.txt");

            /* Rename a File */
            ftpClient.rename("etc/test.txt", "test2.txt");

            /* Create a New Directory */
            ftpClient.createDirectory("etc/test");

            /* Get the Date/Time a File was Created */
            string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
            Console.WriteLine(fileDateTime);

            /* Get the Size of a File */
            string fileSize = ftpClient.getFileSize("etc/test.txt");
            Console.WriteLine(fileSize);

            /* Get Contents of a Directory (Names Only) */
            string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
            for (int i = 0; i < simpleDirectoryListing.Count(); i++) { Console.WriteLine(simpleDirectoryListing[i]); }

            /* Get Contents of a Directory with Detailed File/Directory Info */
            string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
            for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
            /* Release Resources */
            ftpClient = null;
        }
    }
}
