using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using YLADotNetCore.ConsoleApp.Dtos;

namespace YLADotNetCore.ConsoleApp.EFCoreExamples
{
    internal class EfCoreExample
    {
        private readonly AppDbContext dbContext = new AppDbContext();

        public void Run()
        {
            // Read();
            // Edit(1);
            /// Create("Title New", "Author New", "Content New");
            Delete(1008);
            // Update(1002,"Title NewEdit", "Author NewEdit", "Content NewEdit");
        }
        private void Read()
        {

            var lst = dbContext.Blogs.ToList();
            foreach (var item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
                Console.WriteLine("_______________");
            }
        }
        private void Edit(int id)
        {
            var item = dbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found.");
                return;
            }
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            
           

        }
        private void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogAuthor = author,
                BlogTitle = title,
                BlogContent = content
            };
            dbContext.Blogs.Add(item);
            int result = dbContext.SaveChanges();
            string msg = result > 0 ? "Saving Successful." : "Saving Failed";
            Console.WriteLine(msg);

        }
        private void Update(int id, string title, string author, string content)
        {
            var item = dbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found.");
                return;

            }
            item.BlogTitle = title;
            item.BlogContent = content;
            item.BlogAuthor = author;
            int result = dbContext.SaveChanges();
            string msg = result > 0 ? "Updating Successful." : "Updating Failed";
            Console.WriteLine(msg);
        }
        private void Delete(int id)
        {
            var item = dbContext.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item == null)
            {
                Console.WriteLine("No Data Found.");
                return;

            }
            dbContext.Blogs.Remove(item);
            int result = dbContext.SaveChanges();
            string msg = result > 0 ? "Deleting Successful." : "Updating Failed";
            Console.WriteLine(msg);
        }
    }
}
