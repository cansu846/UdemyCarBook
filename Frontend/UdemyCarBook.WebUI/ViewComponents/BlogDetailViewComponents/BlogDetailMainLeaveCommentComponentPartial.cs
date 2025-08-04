using Microsoft.AspNetCore.Mvc;

namespace UdemyCarBook.WebUI.ViewComponents.BlogDetailViewComponents
{
    public class BlogDetailMainLeaveCommentComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(int blogId)
        {
            ViewBag.blogId = blogId;
            return View();
        }
    }
}
