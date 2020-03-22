using FileManagerService.Interfaces.DataItems;
using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace FileManagerService
{
    [ServiceContract]
    public interface IFileService
    {
        [OperationContract]
        DateTime GetServiceTime();

        [OperationContract/*(Name = "Drives", IsInitiating =true, IsOneWay =true, IsTerminating =false)*/]
        DriveInfo[] GetDrives();

        [OperationContract]
        FileInfo[] GetFiles(string Path);

        [OperationContract]
        DirectoryInfo[] GetDirectories(string Path);

        //[OperationContract(IsOneWay = true, IsTerminating = true)]
        //void Disconnect();

        //[OperationContract]
        //IEnumerable<EmployeesData> GetEmployees();

        //[OperationContract(IsOneWay = true)]
        //void AddEmployee(EmployeesData Employee);
    }
}
