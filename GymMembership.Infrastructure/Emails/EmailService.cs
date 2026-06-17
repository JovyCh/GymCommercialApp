using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using GymMembership.Application.Common.Interfaces;
using Resend;

public class EmailService : IEmailService
{
    private readonly IResend _resend;
    public EmailService(IResend resend)
    {
        _resend = resend;
    }
    public async Task<bool> SendEmail(string email)
    {
        try
        {
            var message = new EmailMessage();
            message.From = "onboarding@resend.dev";
            message.To.Add(email);
            message.Subject = "Registration Complete!";
            message.HtmlBody = "Congratulations your registration was complete!";

            var response = await _resend.EmailSendAsync(message);

            return response?.Content != null;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
