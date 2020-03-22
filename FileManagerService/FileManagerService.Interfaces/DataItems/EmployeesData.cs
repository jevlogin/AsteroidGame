using System;
using System.Runtime.Serialization;

namespace FileManagerService.Interfaces.DataItems
{
    [DataContract]
    public class EmployeesData
    {
        [DataMember]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public int DepartamentId { get; set; }
    }
}
