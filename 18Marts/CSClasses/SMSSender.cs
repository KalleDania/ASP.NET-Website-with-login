using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;
using Twilio;
using Twilio.Types;

namespace _18Marts.CSClasses
{
    public class SMSSender
    {

        public async Task SendSms(string _content)
        {
            // Your Account SID from twilio.com/console
            var accountSid = "Ur twilio account id here";
            // Your Auth Token from twilio.com/console
            var authToken = "Ur twilio auth token here";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber("The number you want the messages sent to here"),
                from: new PhoneNumber("Ur twilio number here"),
                body: _content);
        }
    }
}
