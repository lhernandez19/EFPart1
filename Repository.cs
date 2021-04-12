using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EFPart1.DataModels;

namespace EFPart1
{
    public class Repository : IRepository{
        
        //DISPLAY Blogs
        public void displayBlog(){
            using(var db = new BloggingContext())
            {
                foreach (var blog in db.Blogs) 
                {
                    Console.WriteLine($"({blog.BlogId}) {blog.Url}");
                }
            }
        }
        
        //INSERT Blogs
        public void insertBlogs(){
            using(var db = new BloggingContext())
            {
                var blog = new Blog()
                {
                    Rating = 1,
                    Url = "some/url"
                };
                db.Blogs.Add(blog);
                db.SaveChanges();
             }
        }

        //DISPLAY Posts
        public void displayPosts(){
            int blodIDSelected = 0;

            System.Console.Write("Enter blog ID: ");
            blodIDSelected = Int32.Parse(Console.ReadLine());

            using(var db = new BloggingContext())
             {
                 var blog = db.Blogs
                    .Include(b => b.Posts)
                    .ToList()
                    .Find(b => b.BlogId == blodIDSelected);
                
                var posts = blog.Posts.ToArray();

                foreach (var post in posts)
                {
                    Console.WriteLine($"{post.Blog.Url,-10} | {post.Title,-20} | {post.Content,-30}");
                }
                System.Console.WriteLine();

                }
             }
        

        //INSERT to post database
        public void insertPosts(){
            int blodIDSelected = 0;

            System.Console.Write("Enter blog ID: ");
            blodIDSelected = Int32.Parse(Console.ReadLine());

            using(var db = new BloggingContext())
            {
                var blog = db.Blogs
                .Include(b => b.Posts)
                .ToList()
                .Find(b => b.BlogId == blodIDSelected);

                var post = new Post()
                {
                    BlogId = blodIDSelected,
                    Content = "Some content of great importance",
                    Title = "Very important"
                };
                db.Posts.Add(post);
                db.SaveChanges();
             }
        }


    }
    
}


//  //INSERT to blog database
//             using(var db = new BloggingContext())
//             {
//                 var blog = new Blog()
//                 {
//                     Rating = 1,
//                     Url = "some/url"
//                 };
//                 db.Blogs.Add(blog);
//                 db.SaveChanges();
//              }

//             //INSERT to post database
//             using(var db = new BloggingContext())
//             {
//                 var post = new Post()
//                 {
//                     BlogId = 1,
//                     Content = "Some content of great importance",
//                     Title = "Very important"
//                 };
//                 db.Posts.Add(post);
//                 db.SaveChanges();
//              }

//             //INSERT to post database ** same new post id same blogId
//             using(var db = new BloggingContext())
//             {
//                 var post = new Post()
//                 {
//                     BlogId = 1,
//                     Content = "Some content of lesser importance",
//                     Title = "Not so important"
//                 };
//                 db.Posts.Add(post);
//                 db.SaveChanges();
//              }

//             //SELECT from blog database
//              using(var db = new BloggingContext())
//              {
//                 foreach (var blog in db.Blogs) 
//                 {
//                     Console.WriteLine($"({blog.BlogId}) {blog.Url}");
//                 }
//              }

//              //SELECT from blog and post database
//              using(var db = new BloggingContext())
//              {
//                  var blogs = db.Blogs
//                     .Include(b => b.Posts).ToList();

//                 foreach (var blog in db.Blogs) 
//                 {
//                     System.Console.WriteLine("BLOGS");
//                     Console.WriteLine($"({blog.BlogId}) {blog.Url}");

//                     System.Console.WriteLine("POSTS");
//                     var posts = blog.Posts;
//                     foreach (var post in blog.Posts)
//                     {
//                         Console.WriteLine($"({post.PostId}) {post.Title}");
//                     }
//                     System.Console.WriteLine();
//                 }
//              }