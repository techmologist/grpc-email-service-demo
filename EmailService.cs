using System.Net;
using System.Net.Mail;

public class EmailService
{

     internal class Credentials
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    

    public void SendEmail()
    {

        

        //read the email configuration from appsettings.json
        var emailConfig = _configuration.GetSection("Credentials").Get<Credentials>();
        var client = new SmtpClient("smtp.gmail.com", 587)
        {
            Credentials = new NetworkCredential(emailConfig?.Email, emailConfig?.Password),
            EnableSsl = true
            
        };
        client.UseDefaultCredentials = false;

        string ToAddress = "reciever@gmail.com";

        string Subject = "Subject";
        string Body = "Body";


        string? FromAddress = _configuration["Credentials:Email"];



        MailMessage mailMessage = new (FromAddress, ToAddress, Subject, Body)
        {
            
        };

         try
                {
                    client.Send(mailMessage);
                    Console.WriteLine("Email sent successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

            }
}