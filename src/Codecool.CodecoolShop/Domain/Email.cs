using System;
using System.Net;
using System.Net.Mail;

class Email
{

    private MailMessage _message;
    private const string _from = "codecool.eshop@gmail.com";
    private static readonly SmtpClient _client = new("smtp.gmail.com", 587)
    {
        Credentials = new NetworkCredential("codecool.eshop@gmail.com", "larbvyrznzatshsv"),
        EnableSsl = true,
        // specify whether your host accepts SSL connections
    };
    // code in brackets above needed if authentication required
    public Email(string mailTo, string subject, string body)
    {
        _message = new MailMessage(_from, mailTo, subject, body);
    }
    public void Send()
    {
        try
        {
            _client.Send(_message);
        }
        catch (SmtpException ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
