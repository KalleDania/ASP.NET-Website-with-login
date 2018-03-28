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
            var accountSid = "AC859f6c06e103c5653031788712442049";
            // Your Auth Token from twilio.com/console
            var authToken = "123b3131e421fd67acfa68ea0532d87d";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber("+4524250220"),
                from: new PhoneNumber("+4759446477"),
                body: _content);
        }
    }
}
