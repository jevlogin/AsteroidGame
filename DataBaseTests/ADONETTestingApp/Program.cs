namespace ADONETTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection_string = @"Data Source = (localdb)\MSSQLLocalDB;"
                                        + "Initial Catalog = EmployeesDB;"
                                        + "Integrated Security = True;"
                                        + "Connect Timeout = 30;"
                                        + "Encrypt = False;"
                                        + "TrustServerCertificate = False;"
                                        + "ApplicationIntent = ReadWrite;"
                                        + "MultiSubnetFailover = False";
        }
    }
}
