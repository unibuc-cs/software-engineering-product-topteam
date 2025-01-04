using backend_MT.Models;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

public class EmailSender : IEmailSender
{
	private readonly EmailSettings _emailSettings;

	public EmailSender(IOptions<EmailSettings> emailSettings)
	{
		_emailSettings = emailSettings.Value;
	}


	public async Task SendEmailAsync(string email, string subject, string htmlMessage)
	{
		var mimeMessage = new MimeMessage();
		mimeMessage.From.Add(new MailboxAddress(_emailSettings.SenderName, _emailSettings.SenderEmail));
		mimeMessage.To.Add(new MailboxAddress("", email));
		mimeMessage.Subject = subject;

		mimeMessage.Body = new TextPart("html")
		{
			Text = htmlMessage
		};

		try
		{
			using (var smtp = new SmtpClient())
			{
				smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
				await smtp.AuthenticateAsync(_emailSettings.SenderEmail, _emailSettings.Password);
				await smtp.SendAsync(mimeMessage);
				smtp.Disconnect(true);
			}
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Error sending email through Gmail SMTP: " + ex.Message, ex);
		}
	}
}
