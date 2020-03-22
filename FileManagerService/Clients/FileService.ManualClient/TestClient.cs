using System;
using System.ServiceModel;
using FileManagerService;
using System.IO;
using System.ServiceModel.Channels;

namespace FileService.ManualClient
{
    class TestClient : ClientBase<IFileService>, IFileService
    {
        public TestClient(Binding binding, EndpointAddress endpoint) : base(binding, endpoint)
        {

        }
        public DirectoryInfo[] GetDirectories(string Path) => Channel.GetDirectories(Path);

        public DriveInfo[] GetDrives() => Channel.GetDrives();

        public FileInfo[] GetFiles(string Path) => Channel.GetFiles(Path);

        public DateTime GetServiceTime() => Channel.GetServiceTime();
    }
}
