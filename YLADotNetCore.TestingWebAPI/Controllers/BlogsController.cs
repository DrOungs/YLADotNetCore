using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using YLADotNetCore.ConsoleApp.Dtos;
using YLADotNetCore.ConsoleApp.Services;
namespace YLADotNetCore.TestingWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
      
        [HttpGet]
        public IActionResult Read()
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            List<BlogDto> lst = db.Query<BlogDto>("Select * from tbl_blog").ToList();
             return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            var item = db.Query<BlogDto>("Select * from tbl_blog where blogId= @BlogId", new BlogDto { BlogId = id }).FirstOrDefault();
            if (item is null)
            {
                 return NotFound("No data found");
             

            }
            return Ok(item);
        }
        [HttpPost]
        public IActionResult Create(BlogDto blog)
        {
            var item = new BlogDto
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
        public IActionResult Update(int id, BlogDto blog)
        {
            var item = new BlogDto
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
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = new BlogDto
            {
                BlogId = id
            };
            string query = @"Delete from tbl_blog where BlogId=@BlogId";
            using IDbConnection db = new SqlConnection(ConnectionString.SqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(query, item);
            string msg = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(msg);
        }
    }
}
