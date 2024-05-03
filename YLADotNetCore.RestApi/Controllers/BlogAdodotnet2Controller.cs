using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;
using YLADotNetCore.RestApi.Models;
using YLADotNetCore.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace YLADotNetCore.RestApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BlogAdodotnet2Controller : ControllerBase
	{
		private readonly AdoDotNetServices _adoDotNetService = new AdoDotNetServices(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
		[HttpGet]
		public IActionResult GetBlogs()
		{
			string query = "select * from tbl_blog";
			var lst = _adoDotNetService.Query<BlogModel>(query);

			return Ok(lst);
		}
		[HttpGet("id")]
		public IActionResult GetBlog(int id)
		{
			string query = "select * from tbl_blog where BlogId = @BlogId";

			
			var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

			if (item is null)
			{
				return NotFound("No data found.");
			}

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

			int result = _adoDotNetService.Execute(query,
				new AdoDotNetParameter("@BlogTitle", model.BlogTitle),
				new AdoDotNetParameter("@BlogAuthor", model.BlogAuthor),
				new AdoDotNetParameter("@BlogContent", model.BlogContent)
			);

			string message = result > 0 ? "Saving Successful." : "Saving Failed.";
			//return StatusCode(500, message);
			return Ok(message);
		}
		[HttpPut("{id}")]
		public IActionResult PutBlog(int id, BlogModel blog)
		{
			string getQuery = "SELECT COUNT(*) FROM tbl_blog WHERE BlogId = @BlogId";
			var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(getQuery, new AdoDotNetParameter("@BlogId", id)); 
			
			if (item is null) return NotFound();

			string updateQuery = @"UPDATE [dbo].[Tbl_Blog]
								 SET [BlogTitle] = @BlogTitle,
								   [BlogAuthor] = @BlogAuthor,
								   [BlogContent] = @BlogContent
									 WHERE BlogId = @BlogId"
			;
			int result = _adoDotNetService.Execute(updateQuery,
				new AdoDotNetParameter("@BlogId",blog.BlogId),
			new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
				new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
				new AdoDotNetParameter("@BlogContent", blog.BlogContent)
			); 

			string message = result > 0 ? "Updating Successful." : "Updating Failed.";
			//return StatusCode(500, message);
			return Ok(message);
		}

		[HttpPatch]
		public IActionResult PatchBlog(int id, BlogModel model)
		{
			string getQuery = "SELECT COUNT(*) FROM tbl_blog WHERE BlogId = @BlogId";
			var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(getQuery, new AdoDotNetParameter("@BlogId", id));

			if (item is null) return NotFound();

			string updateQuery = @"UPDATE [dbo].[Tbl_Blog]
								 SET [BlogTitle] = @BlogTitle,
								   [BlogAuthor] = @BlogAuthor,
								   [BlogContent] = @BlogContent
									 WHERE BlogId = @BlogId"
			;
			int result = _adoDotNetService.Execute(updateQuery,
				new AdoDotNetParameter("@BlogId", model.BlogId),
			new AdoDotNetParameter("@BlogTitle", model.BlogTitle),
				new AdoDotNetParameter("@BlogAuthor", model.BlogAuthor),
				new AdoDotNetParameter("@BlogContent", model.BlogContent)
			);

			string message = result > 0 ? "Updating Successful." : "Updating Failed.";
			//return StatusCode(500, message);
			return Ok(message);
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteBlog(int id)
		{
			string query = @"DELETE FROM [dbo].[Tbl_blog]
                           WHERE BlogId = @BlogId";
			
			var result= _adoDotNetService.Execute( query, new AdoDotNetParameter("@BlogId", id));
		
			string message = result > 0 ? "Deleting Successful!" : "ီDeleting Failed!";
			return Ok(message);
		}
	}
}
