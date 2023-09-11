using Newtonsoft.Json;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using WebUniversity.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebUniversity.Extensions
{
    public static class ControllerExtension
    {
        public static void SetNotification(this Controller controller, string type, string message)
        {
            var notification = new Notification(type, message);
            controller.TempData["Notification"] = JsonConvert.SerializeObject(notification);
        }
    }
}
