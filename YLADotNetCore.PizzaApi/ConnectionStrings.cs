using Microsoft.Data.SqlClient;

namespace YLADotNetCore.PizzaApi
{
    internal static class ConnectionStrings
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
