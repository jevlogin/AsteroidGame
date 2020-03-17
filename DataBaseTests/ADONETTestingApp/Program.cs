using System;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADONETTestingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var connection_string = @"Data Source = (localdb)\MSSQLLocalDB;"
            //+ "Initial Catalog = EmployeesDB;"
            //+ "Integrated Security = True;";    //  минимальная строка подключения.

            //DbConnectionStringBuilder sb = new DbConnectionStringBuilder() { ConnectionString = connection_string };

            //SqlConnectionStringBuilder sql_sb = new SqlConnectionStringBuilder(connection_string);
            //sql_sb.DataSource = "(localdb)\\MSSQLLocalDB";
            //sql_sb.InitialCatalog = "TestDB";
            //sql_sb.IntegratedSecurity = false;
            //sql_sb.UserID = "Login";
            //sql_sb.Password = "Pass";

            //var new_connection_String = sql_sb.ConnectionString;

            var connection_string = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //ExecuteNonQuery(connection_string);

            ExecuteScalar(connection_string);
        }

        private static string __SqlCountPeoples = @"SELECT COUNT(*) FROM [dbo].[People]";

        private static void ExecuteScalar(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();  //  Создали подключение и открыли его

                var count_command = new SqlCommand(__SqlCountPeoples, connection);
                if (!(count_command.ExecuteScalar() is int count))
                {
                    throw new InvalidOperationException("Ошибка результата команды - не является числом");
                }
            }
        }

        private const string __SqlSelectFromPeople = @"SELECT * FROM [dbo].[People]";
        private static void ExecuteReader(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var select_command = new SqlCommand(__SqlSelectFromPeople, connection);
                using (var reader = select_command.ExecuteReader(CommandBehavior.Default))  //Или поумолчанию.
                {
                    2,05,23
                }
            }
        }

        private const string __SqlCreateTable = @"CREATE TABLE[dbo].[People]
(
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Name]      NVARCHAR(MAX) COLLATE Cyrillic_General_CI_AS NOT NULL,
    [Birthday]  NVARCHAR(MAX) NULL,
    [Email]     NVARCHAR(100) NULL,
    [Phone]     NVARCHAR(MAX) NULL,
    CONSTRAINT[PK_dbo.People] PRIMARY KEY CLUSTERED([Id] ASC)    
);";

        private const string __SqlInsertToPeopleTable = @"INSERT INTO [dbo].[People] (Name,Birthday,Email,Phone) VALUES (N'{0}','{1}','{2}','{3}');";

        private static void ExecuteNonQuery(string ConnectionString)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                //var create_table_command = new SqlCommand(__SqlCreateTable, connection);
                //create_table_command.ExecuteNonQuery();

                var insert_data_command = new SqlCommand(
                    string.Format(__SqlInsertToPeopleTable,
                        "Иванов Иван Иванович",
                        "18.10.2001",
                        "ivanov@mail.ru",
                        "+7-903-1234567"),
                    connection);
                insert_data_command.ExecuteNonQuery();
            }

        }


    }
}
