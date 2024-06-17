using System.Data.SqlClient;

namespace YLADotNetCore.WinFormsAppSqlInjection
{
    internal static class ConnectionStrings
    {

        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DrOungs",
            InitialCatalog = "DotNetTrainging4",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };

    }
}
