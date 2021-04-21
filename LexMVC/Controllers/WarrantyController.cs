using LexMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace LexMVC.Controllers
{
    public class WarrantyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public WarrantyController()
        {

        }
        // GET: Warranty
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Warranty warranty)
        {
            warranty.AvailDate = DateTime.UtcNow;
            db.Warranty.Add(warranty);
            db.SaveChanges();
            SendEmailToCustomer(warranty);
            ViewBag.Message = "Success";
            return View();
        }
        
        private void SendEmailToCustomer(Warranty warranty)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var template = db.MailBodyContent.FirstOrDefault();
                    var mailset = db.EmailSetting.FirstOrDefault();
                    var title = "Your recent Amazon purchase - hidden camera charger from Lexpert Tech LLC.";


                    var body = "<p>Hello " + warranty.FullName + ",</p>" +
                        "" + template.GreetingHeader + "" +
                        "" + template.MiddleContent + "" +
                        "" + template.FooterContent + "";
                    var senderEmail = new MailAddress("asif.rabbani.at@gmail.com", "Asif SHikder");
                    var receiverEmail = new MailAddress(warranty.Email, "Receiver");
                    var password = "#While=0";
                    var sub = title;
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Some Error";
            }
            //try
            //{
            //    var template = db.MailBodyContent.FirstOrDefault();
            //    var mailset = db.EmailSetting.FirstOrDefault();
            //    var title = "Your recent Amazon purchase - hidden camera charger from Lexpert Tech LLC.";


            //    var body = "<p>Hello " + warranty.FullName + ",</p>" +
            //        "" + template.GreetingHeader + "" +
            //        "" + template.MiddleContent + "" +
            //        "" + template.FooterContent + "";
            //    emailSender.Post(
            //              subject: title,
            //              body: body,
            //              recipients: warranty.Email,
            //              sender: configuration["AdminContact"]

            //              );
            //    //emailSender.Post(title,body,warranty.Email,configuration["AdminContact"]);

            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

    }
}