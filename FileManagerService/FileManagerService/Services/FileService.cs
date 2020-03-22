using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerService.Services
{
    [ServiceBehavior(
        //InstanceContextMode = InstanceContextMode.PerSession,
        //ConcurrencyMode = ConcurrencyMode.Multiple,
        //AutomaticSessionShutdown = false,
        IncludeExceptionDetailInFaults = true,
        MaxItemsInObjectGraph = 100_000
        )]
    class FileService : IFileService
    {
        public DirectoryInfo[] GetDirectories(string Path) => new DirectoryInfo(Path).GetDirectories();

        public DriveInfo[] GetDrives() => DriveInfo.GetDrives();

        public FileInfo[] GetFiles(string Path) => new DirectoryInfo(Path).GetFiles();

        public DateTime GetServiceTime() => DateTime.Now;
    }
}
