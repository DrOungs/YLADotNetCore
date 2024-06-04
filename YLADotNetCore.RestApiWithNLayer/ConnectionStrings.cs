using System.Data.SqlClient;

namespace YLADotNetCore.RestApiWithNLayer
{
    public class ConnectionStrings
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
