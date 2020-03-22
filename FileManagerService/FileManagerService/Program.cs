using System;
using System.ServiceModel;

namespace FileManagerService
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(Services.FileService),
                new Uri("http://localhost:8080/FileService"),
                new Uri("net.tcp://localhost/FileService"),
                new Uri("net.pipe://localhost/FileService")
                );

            host.AddDefaultEndpoints(); //  упрощенный вид конфигурации

            host.Open();

            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadLine();

            host.Close();
            ((IDisposable)host).Dispose();
        }
    }
}
