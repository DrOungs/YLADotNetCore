﻿using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YLADotNetCore.ConsoleAppRefitExamples
{
    public interface IBlogApi
    {
        [Get("/api/blog")]
        Task<List<BlogModel>> GetBlogs();

        [Get("/api/blog/{id}")]
        Task<BlogModel> GetBlog(int id);
        
        [Post("/api/blog")]
        Task<string> CreateBlog(BlogModel model);

        [Put("/api/blog/{id}")]
        Task<string> UpdateBlog(int id,BlogModel model);


        [Delete("/api/blog/{id}")]
        Task<string> DeleteBlog(int id);
    }


   
    public class BlogModel
    {        
        public int BlogId { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogAuthor { get; set; }
        public string? BlogContent { get; set; }
    }
}
