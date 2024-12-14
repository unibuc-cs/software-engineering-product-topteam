using backend_MT.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class EmailSender : IEmailSender
{
	private readonly GmailService _gmailService;
	private readonly EmailSettings _emailSettings;

	public EmailSender()
	{
		// Initialize Gmail API
		string[] scopes = { GmailService.Scope.GmailSend };

		// Load credentials
		using var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read);
		var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
			GoogleClientSecrets.FromStream(stream).Secrets,
			scopes,
			"user",
			System.Threading.CancellationToken.None
		).Result;

		// Create Gmail service
		_gmailService = new GmailService(new BaseClientService.Initializer
		{
			HttpClientInitializer = credential,
			ApplicationName = "YourAppName"
		});
	}

	public async Task SendEmailAsync(string email, string subject, string htmlMessage)
	{
		var mimeMessage = new MimeMessage();
		mimeMessage.From.Add(new MailboxAddress("Your App Name", "your-email@gmail.com"));
		mimeMessage.To.Add(new MailboxAddress("", email));
		mimeMessage.Subject = subject;

		mimeMessage.Body = new TextPart("html")
		{
			Text = htmlMessage
		};

		// Convert the MIME message to a base64-encoded string
		using var memoryStream = new MemoryStream();
		mimeMessage.WriteTo(memoryStream);
		var rawMessage = Convert.ToBase64String(memoryStream.ToArray())
			.Replace('+', '-')
			.Replace('/', '_')
			.Replace("=", "");

		// Send the email
		var message = new Message
		{
			Raw = rawMessage
		};

		try
		{
			await _gmailService.Users.Messages.Send(message, "me").ExecuteAsync();
		}
		catch (Exception ex)
		{
			throw new InvalidOperationException("Error sending email with Gmail API: " + ex.Message, ex);
		}
	}
}
