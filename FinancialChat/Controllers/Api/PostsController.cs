using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinancialChat.Models;

namespace FinancialChat.Controllers.Api
{
    public class PostsController : ApiController
    {
        private ApplicationDbContext _context;

        public PostsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/posts/1
        public IHttpActionResult GetPosts(int id = 0)
        {
            var posts = _context.Posts.Where(p => p.RoomId == id).OrderByDescending(o => o.DateTime).Take(50);
            return Ok(posts.OrderBy(o => o.DateTime));
        }
    }
}
