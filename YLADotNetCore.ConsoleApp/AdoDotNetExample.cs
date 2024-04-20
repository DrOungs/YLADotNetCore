using System.Data;
using System.Data.SqlClient;

namespace YLADotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {
        private readonly SqlConnectionStringBuilder _stringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DRAUNG",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "123456"

        };
        public void Read() //Read
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();
            Console.WriteLine("Connection open.");

            string query = "select * from tbl_blog";
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();
            Console.WriteLine("Connection close.");

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine(row["BlogId"]);
                Console.WriteLine(row["BlogTitle"]);
                Console.WriteLine(row["BlogAuthor"]);
                Console.WriteLine(row["BlogContent"]);
                Console.WriteLine("_____________________________");
            }
        }
        public void Edit(int id) //Edit
        {
           
                SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
                connection.Open();
                Console.WriteLine("Connection open.");

                string query = "select * from tbl_blog where BlogId=@BlogId";
                SqlCommand cmd = new SqlCommand(query, connection);
                      cmd.Parameters.AddWithValue("@BlogId", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqlDataAdapter.Fill(dt);
                connection.Close();
            if (dt.Rows.Count==0)
            {
                Console.WriteLine("No data found.");
                return;
            }
            DataRow dr = dt.Rows[0];
                    Console.WriteLine("BlogId =>" + dr["BlogId"]);
                    Console.WriteLine("BlogTitle =>" + dr["BlogTitle"]);
                    Console.WriteLine("BlogAuthor =>" + dr["BlogAuthor"]);
                    Console.WriteLine("BlogContent =>" + dr["BlogContent"]);
                    Console.WriteLine("_____________________________");
        
         
        }
        public void Create(string title, string author, string content) //Create
        {
            SqlConnection connection = new SqlConnection(_stringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                               ([BlogTitle]
                               ,[BlogAuthor]
                               ,[BlogContent])
                                 VALUES
                               (@BlogTitle
                               ,@BlogAuthor
                               ,@BlogContent)";

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
       
            Console.WriteLine(message);
        }
        public void Update(int id,string title, string author, string content) //Update
        {
            SqlConnection con= new SqlConnection(_stringBuilder.ConnectionString);
            con.Open();

            string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId= @BlogId";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);
            int result = cmd.ExecuteNonQuery();
            con.Close();
            string message = result > 0 ? "Update Successful." : "Update Failed.";

            Console.WriteLine(message);
        }
        public void Delete(int id) //date
        {
            SqlConnection conn = new SqlConnection(_stringBuilder.ConnectionString);
            conn.Open();
            string query = @"DELETE FROM [dbo].[Tbl_Blog]
                                WHERE BlogId= @BlogId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@BlogId", id);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";

            Console.WriteLine(message);
        }
    }
}
