using System.Net;
using System.Net.Mail;

namespace SamsungWatch.Utilities.Mail;

public class SendMail
{
    public static void SendEmail(string toEmail, string subject, string body, string attachFile)
    {
        try
        {
            using (var client = new SmtpClient(ConstantHelper.hostMail, ConstantHelper.portEmail))
            {
                MailMessage msg = new MailMessage(ConstantHelper.email, toEmail, subject, body);
                client.EnableSsl = true;

                if (!string.IsNullOrEmpty(attachFile))
                {
                    Attachment attachment = new Attachment(attachFile);
                    msg.Attachments.Add(attachment);
                }
                NetworkCredential credential = new NetworkCredential(ConstantHelper.email, ConstantHelper.pass);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                msg.IsBodyHtml = true;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                client.Credentials = credential;
                client.Send(msg);
            }
        }
        catch (Exception)
        {
        }
    }
}