using System;
using System.Configuration;
using System.Net.Mail;

namespace Questionnaire.Models
{
    public class Message
    {
        public void Send ( 
            string personName, 
            int numberOfCorrect, 
            int numberOfIncorrect )
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From =
                new MailAddress( Configuration.MessageSender );
            mailMessage.Subject = "Questionnaire Results for " + personName;
            mailMessage.Body =
                string.Format(
                    "{0}\n\nNumber Of Correct Questions: {1}\nNumber Of Incorrect Questions: {2}",
                    personName,
                    numberOfCorrect,
                    numberOfIncorrect );
            mailMessage.To.Add( Configuration.MessageRecipient );
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = Configuration.MessageServer;
            smtpClient.Send( mailMessage );
        }
    }
}
