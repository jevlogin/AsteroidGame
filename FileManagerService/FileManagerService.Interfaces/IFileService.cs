using System.IO;
using System.ServiceModel;

namespace FileManagerService
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        DriveInfo[] GetDrives();

        [OperationContract]
        FileInfo[] GetFiles(string Path);

        [OperationContract]
        DirectoryInfo[] GetDirectories(string Path);
    }
}
