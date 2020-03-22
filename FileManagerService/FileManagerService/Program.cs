using System;
using System.ServiceModel;
using System.ServiceModel.Description;

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

            //host.AddDefaultEndpoints(); //  упрощенный вид конфигурации

            host.AddServiceEndpoint(
                typeof(IFileService),
                new BasicHttpBinding(),
                "http://localhost:8080/FileService"
                );
            host.AddServiceEndpoint(
                typeof(IFileService),
                new NetTcpBinding(),
                "net.tcp://localhost/FileService"
                );

            host.AddServiceEndpoint(
                typeof(IFileService),
                new NetNamedPipeBinding(),
                "net.pipe://localhost/FileService"
                );

            host.Description.Behaviors.Add(new ServiceMetadataBehavior());

            const string mex_address = "mex";
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexHttpBinding(), mex_address);
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexTcpBinding(), mex_address);
            host.AddServiceEndpoint(typeof(IMetadataExchange), MetadataExchangeBindings.CreateMexNamedPipeBinding(), mex_address);

            host.Open();

            Console.WriteLine("Нажмите Enter для выхода");
            Console.ReadLine();

            host.Close();
            ((IDisposable)host).Dispose();
        }
    }
}
