using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            var values = _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            var values = _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla güncellendi.");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var values = _commentContext.UserComments.Find(id);
            _commentContext.Remove(values);
            _commentContext.SaveChanges();
            return Ok("Yorum başarıyla silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _commentContext.UserComments.Find(id);
            return Ok(values);
        }

        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var value = _commentContext.UserComments.Where(x=>x.ProductId == id);
            return Ok(value);
        }

        [HttpGet("GetActiveCommentCount")]
        public IActionResult GetActiveCommentCount()
        {
            int value = _commentContext.UserComments.Where(x => x.Status == true).Count();
            return Ok(value);
        }

        [HttpGet("GetPassiveCommentCount")]
        public IActionResult GetPassiveCommentCount()
        {
            int value = _commentContext.UserComments.Where(x => x.Status == false).Count();
            return Ok(value);
        }

        [HttpGet("GetTotalCommentCount")]
        public IActionResult GetTotalCommentCount()
        {
            int value = _commentContext.UserComments.Count();
            return Ok(value);
        }
    }
}
