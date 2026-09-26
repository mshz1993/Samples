using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyNUnitTest.Controllers;
using NUnit.Framework;

namespace MyNUnitTest.Models
{
    public class Post
    {
        public static List<Post> Posts=new List<Post>()
        {
            new Post(){Title = "سایت تاپ لرن",Content = "مرجع فیلم های آموزشی فارسی زبان"},
            new Post(){Title = "تست نرم افزار",Content = "تست نرم افزار کار خوبی است"}
        }; 

        public string Title { get; set; }
        public string Content { get; set; }
       
    }

    [TestFixture]
    public class PostTests
    {

        [Test]
        public void ShouldDisplayListPost()
        {
            var viewResult = new PostController().Index() as ViewResult;

            Assert.AreEqual(Post.Posts,viewResult.Model);
            Assert.IsNotNull(viewResult.Model);
        }

        [Test]
        public void ShouldLoadCreateView()
        {
            var viewResult = new PostController().Create() as ViewResult;
            Assert.AreNotEqual(null,viewResult);
        }

        [Test]
        public void ShouldAddPost()
        {
            var post = new Post()
            {
                Title ="تست پست ها",
                Content = "تست برای پست ها"
            };

            var redirect = new PostController().Create(post) as RedirectToRouteResult;
            Assert.Contains(post,Post.Posts);
            Assert.AreEqual("Index",redirect.RouteValues["action"]);
        }
    }
}