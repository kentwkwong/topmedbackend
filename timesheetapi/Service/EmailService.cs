using timesheetapi.Model;

namespace timesheetapi.Service;
using System.Net;
using System.Net.Mail;

public class EmailService
{
    public static string SendEmail(Timesheet timesheet)
    {
        var fromAddress = new MailAddress("wkwong.ca@gmail.com", "Wing Wong");
        var toAddress = new MailAddress("kentwkwong@gmail.com", "kentwong");
        const string fromPassword = "hxhu xrpk hxwl dcxq";
        
        var partners = string.Join(",", timesheet.PartnersName);
        var lunch = (timesheet.HasLunch) ? "with lunch" : "no lunch";
        var difference = timesheet.WorkTo - timesheet.WorkFrom;
        if (timesheet.HasLunch)
        {
            var lunchSpan = new TimeSpan(0, 30, 0);
            difference = difference.Subtract(lunchSpan);
        }
        var hours = difference.Hours;
        var minutes = difference.Minutes;
        
        var subject = $"{timesheet.DisplayName} Timesheet {timesheet.WorkFrom.ToString(("yyMMdd"))}";
        var body = $"{timesheet.WorkFrom.ToString(("dd-MMM-yyyy"))} {timesheet.WorkFrom.DayOfWeek}";
        body += $"<br />{timesheet.WorkFrom:HHmm}-{timesheet.WorkTo:HHmm}";
        body += $"<br />{timesheet.TruckNum}";
        body += $"<br />{partners} {lunch}";
        body += $"<br />{hours} Hours {minutes} minutes";
        body += $"<br /><br /><br />Powered by Kent Timesheet App";

        var smtp = new SmtpClient
        {
            Host = "smtp.gmail.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            UseDefaultCredentials = false,
            Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
        };
        using (var message = new MailMessage(fromAddress, toAddress)
               {
                   IsBodyHtml = true,
                   Subject = subject,
                   Body = body,
                   CC = { fromAddress }
               })
        {
            smtp.Send(message);
        }

        return "Done!";
    }
}





