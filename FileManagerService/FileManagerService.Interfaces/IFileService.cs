using System.IO;
using System.ServiceModel;

namespace FileManagerService
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract(Name = "Drives", IsInitiating =true, IsOneWay =true, IsTerminating =false)]
        DriveInfo[] GetDrives();

        [OperationContract]
        FileInfo[] GetFiles(string Path);

        [OperationContract]
        DirectoryInfo[] GetDirectories(string Path);
    }
}
