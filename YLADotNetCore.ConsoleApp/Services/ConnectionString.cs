using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YLADotNetCore.ConsoleApp.Services
{
    public static class ConnectionString
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DRAUNG",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "123456",
            TrustServerCertificate = true
        };
    }
}
