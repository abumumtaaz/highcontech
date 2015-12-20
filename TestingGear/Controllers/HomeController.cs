using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TestingGear.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }


        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Contact(string name, string uEmail, string subject, string message)
        {
            try
            {
                var from = ConfigurationManager.AppSettings.Get("UserID");
                using (var email = new MailMessage(from, "highcontech@gmail.com"))
                {
                    email.Subject = "Contact - " + subject;
                    email.Body = name + " sent a message from within the highcontech website. \nMessage Content: \n" + message + "\n\nEmail Address: " + uEmail;
                    email.IsBodyHtml = false;
                    var smtp = new SmtpClient();
                    await smtp.SendMailAsync(email);
                }
                using (var email2 = new MailMessage("highcontech@gmail.com", uEmail))
                {
                    email2.Subject = "Highcon Technologies";
                    email2.Body = "Thank you for contacting us at Highcon Technologies.\n" +
                           "We have received your request and I want to asure you that necessary " +
                           "actions would be taken as fast as possible, so you may not need to " +
                           "resend this.\nYou would be contacted if need be as soon as possible.\nThank You.\n\n-------------" +
                           "\nBest Regards;\nHighconTech team.";
                    email2.IsBodyHtml = false;
                    var smtp = new SmtpClient();
                    await smtp.SendMailAsync(email2);
                }

                ViewBag.Status = "SUCCESS";
                ViewBag.StatusMessage = "Message successfully sent";
            }
            catch (Exception)
            {
                ViewBag.Status = "ERROR";
                ViewBag.StatusMessage = "Something went wrong. Please retry.";
            }
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Products()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Training2015()
        {
            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}
