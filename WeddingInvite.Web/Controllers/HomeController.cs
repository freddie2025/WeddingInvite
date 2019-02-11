using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web.Configuration;
using System.Web.Mvc;
using WeddingInvite.Web.Models;

namespace WeddingInvite.Web.Controllers
{
	public class HomeController : Controller
	{
		// GET: Default
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(MailModels e)
		{
			if (ModelState.IsValid)
			{
				//prepare email
				var toAddress = WebConfigurationManager.AppSettings["MAIL_ACCOUNT"];
				var fromAddress = e.Email.ToString();
				var subject = "RSVP for " + e.Name;
				var message = new StringBuilder();
				message.Append("Name: " + e.Name + "\n");
				message.Append("Email: " + e.Email + "\n");
				message.Append(e.Message);

				//start email Thread
				var tEmail = new Thread(() => SendEmail(toAddress, fromAddress, subject, message.ToString()));
				tEmail.Start();
			}

			ViewBag.Visibility = true;

			var mailModel = new MailModels();
			ModelState.Clear();
			return View(mailModel);
		}

		public void SendEmail(string toAddress, string fromAddress, string subject, string message)
		{
			try
			{
				using (var mail = new MailMessage())
				{
					string email = WebConfigurationManager.AppSettings["MAIL_ACCOUNT"];
					string password = WebConfigurationManager.AppSettings["MAIL_PASSWORD"];

					var loginInfo = new NetworkCredential(email, password);
					mail.From = new MailAddress(fromAddress);
					mail.To.Add(new MailAddress(toAddress));
					mail.Subject = subject;
					mail.Body = message;
					mail.IsBodyHtml = true;

					try
					{
						using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
						{
							smtpClient.EnableSsl = true;
							smtpClient.UseDefaultCredentials = false;
							smtpClient.Credentials = loginInfo;
							smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
							smtpClient.Send(mail);
						}
					}
					finally
					{
						//dispose the client
						mail.Dispose();
					}
				}
			}
			catch (SmtpFailedRecipientsException ex)
			{
				foreach (SmtpFailedRecipientException t in ex.InnerExceptions)
				{
					var status = t.StatusCode;
					if (status == SmtpStatusCode.MailboxBusy || status == SmtpStatusCode.MailboxUnavailable)
					{
						Response.Write("Delivery failed - retrying in 5 seconds.");
						System.Threading.Thread.Sleep(5000);
						//resend
						//smtpClient.Send(message);
					}
					else
					{
						Response.Write(String.Format("Failed to deliver message to {0}", t.FailedRecipient));
					}
				}
			}
			catch (SmtpException Se)
			{
				// handle exception here
				Response.Write(Se.ToString());
			}
			catch (Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}
	}
}