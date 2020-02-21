using MimeKit;
using System.Data;
using System.Data.Odbc;
using System.Net.Mail;
using MailKit.Net.Smtp;
namespace BLM.Models
{
    internal class Connection
    {
        public static void dbCommand(string command)
        {
            OdbcConnection dbConnection = new OdbcConnection("DSN=FLC");
            dbConnection.Open();
            OdbcCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = command;
            OdbcDataReader DbReader = dbCommand.ExecuteReader();
            dbConnection.Close();
        }

        public static DataTable dbTable(string query)
        
        {
            OdbcConnection dbConnection = new OdbcConnection("DSN=FLC");
            dbConnection.Open();
            OdbcCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = query;
            OdbcDataReader DbReader = dbCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(DbReader);
            dbConnection.Close();
            return dt;
        }

        public static bool verifyLogin(string username, string password)
        {
            DataTable dt = dbTable("select * from users where Username='" + username + "' and Password = '" + password + "';");
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else
                return false;
        }

        public static void sendEmail(string subject, string body, string name, string email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("flc.email.bot", "flc.email.bot@gmail.com"));
            message.To.Add(new MailboxAddress(name, email));
            message.Subject = subject;

            message.Body = new TextPart("plain")
            {
                Text = body
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate("flc.email.bot@gmail.com", "capstoning");
                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}