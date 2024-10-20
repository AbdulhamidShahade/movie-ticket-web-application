using Microsoft.AspNetCore.Mvc;

namespace MovieTicket.Web.Helpers
{
    public static class NotificationHalper
    {
        public static void SetNotification(Controller controller, string type, string message)
        {
            controller.TempData[type] = message;
        }
    }
}