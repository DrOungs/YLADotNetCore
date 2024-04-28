using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YLADotNetCore.RestApi.Db;
using YLADotNetCore.RestApi.Models;

namespace YLADotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BlogController()
        {
                _context = new AppDbContext();
        }
        [HttpGet]
        public IActionResult Read()
        {
            var lst= _context.Blogs.ToList();

            return Ok(lst);
        }
        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            var lst = _context.Blogs.FirstOrDefault(x=>x.BlogId==id);
            if (lst is null)
            {
                return NotFound("No Data");
            }
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult Create(BlogModel blog) 
        {
            _context.Blogs.Add(blog);
          var result=  _context.SaveChanges();
            string msg = result > 0 ? "Saving Successful" : "Saving Failed";
            return Ok(msg);

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,BlogModel blog)
        {
            var itm= _context.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if (itm is null)
            {
                return NotFound("No data found");

            }
            itm.BlogTitle = blog.BlogTitle;
            itm.BlogAuthor = blog.BlogAuthor;
            itm.BlogContent= blog.BlogContent;
            var result = _context.SaveChanges();
            string msg = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(msg);
        }
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, BlogModel blog)
        {
            var itm = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (itm is null)
            {
                return NotFound("No data found");

            }
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
            itm.BlogTitle = blog.BlogTitle;
            }
           if(!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                itm.BlogAuthor = blog.BlogAuthor;
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            { 
                itm.BlogContent = blog.BlogContent; 
            }
            var result = _context.SaveChanges();
            string msg = result > 0 ? "Updating Successful" : "Updating Failed";
            return Ok(msg);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var itm= _context.Blogs.FirstOrDefault(x=>x.BlogId == id);
            if (itm is null)
            { return NotFound("No data found");
            }
            _context.Blogs.Remove(itm);
            var result = _context.SaveChanges();
            string msg = result > 0 ? "Deleting Successful" : "Deleting Failed";
            return Ok(msg);
        }

    }
}
