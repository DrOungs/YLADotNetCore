// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = "Desktop-240BQZ";//server Name
stringBuilder.InitialCatalog = "DotNetTrainingBatch4";// db name
stringBuilder.UserID = "sa";  // Name
stringBuilder.Password= "sasa@@123"; // Password
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);
connection.Open();
Console.WriteLine("Connection open.");

string query = "select * from tbl_blog";
SqlCommand cmd= new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt= new DataTable();
sqlDataAdapter.Fill(dt);
connection.Close();
Console.WriteLine("Connection close.");

foreach(DataRow dr in dt.Rows)
{
    Console.WriteLine("Blog Id", dr["BlogId"]);
    Console.WriteLine("Blog Title", dr["BlogTitle"]);
    Console.WriteLine("Blog Author", dr["BlogAuthor"]); 
    Console.WriteLine("Blog Content", dr["BlogContent"]);
    Console.WriteLine("_____________________________");
}



Console.ReadKey();