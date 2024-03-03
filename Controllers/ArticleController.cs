using EnterpriceWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;

namespace EnterpriceWeb.Controllers
{
    public class ArticleController : Controller
    {
        private readonly AppDbConText _dbContext;
        public ArticleController(AppDbConText dbContext)
        {
            _dbContext = dbContext;
        }

        //CreateArticle index

        //UpdateArticle index

        //DeleteArticle index


        //CreateFeedback
        public IActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Feedback(int Article_id, string fb_content)
        {
            if (ModelState.IsValid)
            {
                //create fb
                //_dbContext.Feedbacks.Add(newFeedback);
                _dbContext.SaveChanges();

            }
            return View("~/Feedback/" + Article_id);
        }

        //UpdateFeedback
        public IActionResult Feedback(int fb_id)
        {
            //var feedback = _dbContext.feedbacks.Find(fb_id);
            //if(feedback != null)
            //{
            //TempData["feedback"] = feedback;
            return View();
        //{
        //else
        //{
        return View("~/Home/Erorr404");
        //}
        }

        //DeleteFeedback
        [HttpDelete]
        public IActionResult Delete(int fb_id) {
            //var feedback = _dbContext.feedbacks.Find(fb_id);
            //if(feedback != null)
            //{
             //   _dbContext.feedbacks.Remove(feedback);
               // _dbContext.SaveChanges();
           // }
            return View(); 
        }
    }
}
