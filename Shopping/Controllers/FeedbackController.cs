using Microsoft.AspNetCore.Mvc;
using Shopping.Models;

namespace Shopping.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpPost]
        public JsonResult SendFeedback(FeedbackModel model)
        {
            if (ModelState.IsValid)
            {
                // отправляем сообщение...
                return Json(new { result = "Сообщение отправлено" });
            }
            else
            {
                return Json(new { error = "ошибка в заполнении формы" });
            }
        }
    }
}
