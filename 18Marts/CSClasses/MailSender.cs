using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace _18Marts.CSClasses
{
    public class MailSender
    {
        public MailSender()
        {

        }

        public void SendAccessUpgradeRequest(string _who, string _mail)
        {
            Send(_who + " " + _mail, "AccessUpgradeRequest");
        }

        public void SendFeedback(string _theFeedback)
        {
            Send(_theFeedback, "Feedback");
        }

        private void Send(string _content, string _subject)
        {
            // only works if sender is using a gmail
            // https://myaccount.google.com/lesssecureapps are turned off byb default but must be turned on for a 3rd party app to use the mail.


            MailMessage mail = new MailMessage("Ur sender mail here", "Ur receiver mail here");
            mail.Subject = "Some subject: " + _subject;
            mail.Body = _content;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "ur mail here",
                Password = "ur pw for that mail"
            };

            smtpClient.EnableSsl = true;

            ServicePointManager.ServerCertificateValidationCallback = delegate (object s,
                     System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                     System.Security.Cryptography.X509Certificates.X509Chain chain,
                     System.Net.Security.SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };

            smtpClient.Send(mail);
        }
    }
}
