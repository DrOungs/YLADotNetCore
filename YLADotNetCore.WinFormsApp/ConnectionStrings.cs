using System.Data.SqlClient;

namespace YLADotNetCore.WinFormsApp
{
    public class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DRAUNG",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "123456",
            TrustServerCertificate = true
        };
    }
}
