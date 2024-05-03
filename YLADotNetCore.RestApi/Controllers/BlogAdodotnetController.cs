using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;
using YLADotNetCore.RestApi.Models;

namespace YLADotNetCore.RestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogAdodotnetController : ControllerBase
	{
		[HttpGet]
		public IActionResult GetBlogs()
		{
			SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			connection.Open();
			Console.WriteLine("Connection open.");

			string query = "select * from tbl_blog";
			SqlCommand cmd = new SqlCommand(query, connection);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			sqlDataAdapter.Fill(dt);
			connection.Close();
			//List<BlogModel> lst= new List<BlogModel>();
			//foreach (DataRow dr in dt.Rows)
			//{
			//	BlogModel blog= new BlogModel();
			//	blog.BlogId = Convert.ToInt32(dr["BlogId"]);
			//	blog.BlogTitle = Convert.ToString(dr["BlogTitle"]);
			//	blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
			//	blog.BlogContent = Convert.ToString(dr["BlogContent"]);
			//	lst.Add(blog);
			//}
			List<BlogModel> lst= dt.AsEnumerable().Select(dr=>new BlogModel
			{
				BlogId = Convert.ToInt32(dr["BlogId"]),
				BlogTitle = Convert.ToString(dr["BlogTitle"]),
				BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
				BlogContent = Convert.ToString(dr["BlogContent"])

		}).ToList();
			return Ok(lst);
		}
		[HttpGet("id")]
		public IActionResult GetBlog(int id)
		{
			string query = "Select * from tbl_blog where BlogId=@BlogId";
			SqlConnection conn= new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			conn.Open();
			SqlCommand cmd= new SqlCommand(query, conn);
			cmd.Parameters.AddWithValue("@BlogId",id);
			SqlDataAdapter sqlDataAdapter= new SqlDataAdapter(cmd);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			conn.Close();
			if (dataTable.Rows.Count == 0)
			{
				return NotFound("Not Found");
			}
			DataRow dr = dataTable.Rows[0];
			var item = new BlogModel
			{
				BlogId = Convert.ToInt32(dr["BlogId"]),
				BlogTitle = Convert.ToString(dr["BlogTitle"]),
				BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
				BlogContent = Convert.ToString(dr["BlogContent"])

			};
			return Ok(item);
		}
		[HttpPost]
		public IActionResult CreateBlog(BlogModel model)
		{
			string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
			VALUES
           (@BlogTitle
           ,@BlogAuthor       
           ,@BlogContent)";

			SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			connection.Open();

			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@BlogTitle", model.BlogTitle);
			cmd.Parameters.AddWithValue("@BlogAuthor", model.BlogAuthor);
			cmd.Parameters.AddWithValue("@BlogContent", model.BlogContent);
			int result = cmd.ExecuteNonQuery();

			connection.Close();

			string message = result > 0 ? "Saving Successful!" : "Saving Failed!";
			
			return Ok(message);
		}
		[HttpPut("{id}")]
		public IActionResult PutBlog(int id, BlogModel blog)
		{
			string getQuery = "SELECT COUNT(*) FROM tbl_blog WHERE BlogId = @BlogId";
			SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			connection.Open();
			SqlCommand checkCmd = new SqlCommand(getQuery, connection);
			checkCmd.Parameters.AddWithValue("@BlogId", id);
			var count = (int)checkCmd.ExecuteScalar();
			if (count == 0) return NotFound();

			string updateQuery = @"UPDATE [dbo].[Tbl_Blog]
								 SET [BlogTitle] = @BlogTitle,
								   [BlogAuthor] = @BlogAuthor,
								   [BlogContent] = @BlogContent
									 WHERE BlogId = @BlogId";

			SqlCommand cmd = new SqlCommand(updateQuery, connection);
			cmd.Parameters.AddWithValue("@BlogId", id);
			cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
			cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
			cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
			int result = cmd.ExecuteNonQuery();
			connection.Close();
			string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
			return Ok(message);
		}

		[HttpPatch]
		public IActionResult PatchBlog(int id, BlogModel model)
		{
			string getQuery = "SELECT COUNT(*) FROM tbl_blog WHERE BlogId = @BlogId";
			SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			connection.Open();
			SqlCommand checkCmd = new SqlCommand(getQuery, connection);
			checkCmd.Parameters.AddWithValue("@BlogId", id);
			var count = (int)checkCmd.ExecuteScalar();
			if (count == 0) return NotFound();

			string updateQuery = @"UPDATE [dbo].[Tbl_Blog]
                           SET [BlogTitle] = @BlogTitle,
                               [BlogAuthor] = @BlogAuthor,
                               [BlogContent] = @BlogContent
                           WHERE BlogId = @BlogId";

			SqlCommand cmd = new SqlCommand(updateQuery, connection);
			cmd.Parameters.AddWithValue("@BlogId", id);
			cmd.Parameters.AddWithValue("@BlogTitle", model.BlogTitle);
			cmd.Parameters.AddWithValue("@BlogAuthor", model.BlogAuthor);
			cmd.Parameters.AddWithValue("@BlogContent", model.BlogContent);
			int result = cmd.ExecuteNonQuery();

			string message = result > 0 ? "Updating Successful!" : "Updating Failed!";
			return Ok(message);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBlog(int id)
		{
			string query = @"DELETE FROM [dbo].[Tbl_blog]
                           WHERE BlogId = @BlogId";
			SqlConnection connection = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			connection.Open();

			SqlCommand cmd = new SqlCommand(query, connection);
			cmd.Parameters.AddWithValue("@BlogId", id);

			int result = cmd.ExecuteNonQuery();
			connection.Close();

			string message = result > 0 ? "Deleting Successful!" : "ီDeleting Failed!";
			return Ok(message);
		}
	}
}
