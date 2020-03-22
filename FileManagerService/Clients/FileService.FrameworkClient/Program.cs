using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using FileService.FrameworkClient.Clients;

namespace FileService.FrameworkClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //var client = new FileServiceClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:8080/FileService"));
            var client = new FileServiceClient();

            var drives = client.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine(drive);
            }

            Console.WriteLine(new string('-', Console.BufferWidth));

            var files = client.GetFiles(@"c:\");
            foreach (var file in files)
            {
                Console.WriteLine(file);
            }

            Console.ReadLine();
        }
    }
}
