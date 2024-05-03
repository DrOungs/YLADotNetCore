using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using YLADotNetCore.RestApi.Models;
using Dapper;

namespace YLADotNetCore.RestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogDapperController : ControllerBase
	{
		[HttpGet]
		public IActionResult Read()
		{
			string query = "select * from tbl_blog";
			using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			List<BlogModel> lst = db.Query<BlogModel>(query).ToList();
			return Ok(lst);
		}
		[HttpGet("{id}")]
		public IActionResult Edit(int id)
		{
			using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			var item = db.Query<BlogModel>("Select * from tbl_blog where blogId= @BlogId", new BlogModel { BlogId = id }).FirstOrDefault();
			if (item is null)
			{
				return NotFound("No data found");


			}
			return Ok(item);
		}
		[HttpPost]
		public IActionResult Create(BlogModel blog)
		{
			var item = new BlogModel
			{
				BlogTitle = blog.BlogTitle,
				BlogAuthor = blog.BlogAuthor,
				BlogContent = blog.BlogContent
			};
			string qurey = @"INSERT INTO [dbo].[Tbl_Blog]
                               ([BlogTitle]
                               ,[BlogAuthor]
                               ,[BlogContent])
                                 VALUES
                               (@BlogTitle
                               ,@BlogAuthor
                               ,@BlogContent)";
			using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			int result = db.Execute(qurey, item);
			string msg = result > 0 ? "Saving Successful" : "Saving Failed";
			return Ok(msg);

		}
		[HttpPut("{id}")]
		public IActionResult Update(int id, BlogModel blog)
		{
			var item = new BlogModel
			{
				BlogId = id,
				BlogTitle = blog.BlogTitle,
				BlogAuthor = blog.BlogAuthor,
				BlogContent = blog.BlogContent
			};
			string query = @"UPDATE [dbo].[Tbl_Blog]
                            SET [BlogTitle] = @BlogTitle
                            ,[BlogAuthor] = @BlogAuthor
                            ,[BlogContent] = @BlogContent
                            WHERE BlogId= @BlogId";
			using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			int result = db.Execute(query, item);
			string msg = result > 0 ? "Updating Successful" : "Updating Failed";
			return Ok(msg);
		}
		[HttpPatch("{id}")]
		public IActionResult PatchBlog(int id, BlogModel blog)
		{
			var item = FindbyId(id);
			if (item is null)
			{
				return NotFound("No data found.");
			}

			string conditions = string.Empty;
			if (!string.IsNullOrEmpty(blog.BlogTitle))
			{
				conditions += " [BlogTitle] = @BlogTitle, ";
			}
			if (!string.IsNullOrEmpty(blog.BlogAuthor))
			{
				conditions += " [BlogAuthor] = @BlogAuthor, ";
			}
			if (!string.IsNullOrEmpty(blog.BlogContent))
			{
				conditions += " [BlogContent] = @BlogContent, ";
			}

			if (conditions.Length == 0)
			{
				return NotFound("No data to update.");
			}

			conditions = conditions.Substring(0, conditions.Length - 2);
			blog.BlogId = id;

				string query = $@"UPDATE [dbo].[Tbl_Blog]
								 SET {conditions}
								WHERE BlogId = @BlogId";

			using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			int result = db.Execute(query, blog);

			string message = result > 0 ? "Updating Successful." : "Updating Failed.";
			return Ok(message);
		}
		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var item = FindbyId(id);
			if (item is null)
			{
				return NotFound("No data found");

			}

			string query = @"Delete from tbl_blog where BlogId=@BlogId";
			using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			int result = db.Execute(query, item);
			string msg = result > 0 ? "Deleting Successful" : "Deleting Failed";
			return Ok(msg);
		}
		private BlogModel? FindbyId(int id)
		{
			string query = "Select * from tbl_blog where blogId=@BlogId";
			using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
			var item = db.Query<BlogModel>(query, new BlogModel { BlogId = id }).FirstOrDefault();
			return item;
		}
	}
}
