using System;
using System.Runtime.Serialization;

namespace FileManagerService.Interfaces.DataItems
{
    [DataContract]
    public class EmployeesData
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime BirthDay { get; set; }

        [DataMember]
        public int DepartamentId { get; set; }
    }
}
