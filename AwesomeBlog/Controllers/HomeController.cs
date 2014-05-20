using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeBlog.Controllers
{
    public class HomeController : Controller
    {
        //Step 1. Set up database access
        Models.My_BlogEntities db = new Models.My_BlogEntities();

        //
        // GET: /Home/

        public ActionResult Index()
        {
            var list = db.blogstuufs.OrderByDescending(x => x.DatePosted);
            return View(list);
        }

        public ActionResult Rating(int id)
        {
            var post = db.blogstuufs.Where(x => x.PostID == id).First();
            post.Rating += 1;
            db.SaveChanges();

            return Content("Rated " + post.Rating);
        }

        public ActionResult AddComment(int id, FormCollection values)
        {
            var comment = new Models.Comment();
            comment.PostID = id;
            comment.author = values["author"];
            comment.body = values["body"];
            comment.postedOn = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.Rating = 0;
            //add comment to database
            db.Comments.Add(comment);
            db.SaveChanges();

            var post = db.blogstuufs.Find(id);

            return PartialView("Comment", post);
        }

    }
}
