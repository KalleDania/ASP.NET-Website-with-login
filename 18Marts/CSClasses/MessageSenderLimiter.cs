using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _18Marts.CSClasses
{
    public class MessageSenderLimiter
    {
        private static MessageSenderLimiter instance = null;
        public static MessageSenderLimiter Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MessageSenderLimiter();
                }
                return instance;
            }
        }

        private MessageSenderLimiter()
        {
            // Initialize.
        }

        private const int maxMessagePrCategory = 3;
        private string ip;
        private int requestAccessCount;
        private int feedbackCount;
        private DateTime timeOfFirstMessage; 

        public bool AllowSendMessage(string _ip, string _messageType)
        {
            if (ip == _ip)
            {
                // Hvis der er gået mere end en time siden første besked, reset besked counterne.
                if (DateTime.Now > timeOfFirstMessage.AddHours(1))
                {
                    requestAccessCount = 0;
                    feedbackCount = 0;
                    timeOfFirstMessage = DateTime.Now;
                }

                switch (_messageType)
                {
                    case "RequestAccess":

                        if (requestAccessCount < maxMessagePrCategory)
                        {
                            requestAccessCount++;
                            return true;
                        }

                        else
                        {
                            return false;
                        }
               

                    case "Feedback":
                        if (feedbackCount < maxMessagePrCategory)
                        {
                            feedbackCount++;
                            return true;
                        }

                        else
                        {
                            return false;
                        }
                }
            }

            else
            {
                ip = _ip;
                requestAccessCount = 0;
                feedbackCount = 0;
                timeOfFirstMessage = DateTime.Now;

                switch (_messageType)
                {
                    case "RequestAcces":
                        requestAccessCount++;
                        break;

                    case "Feedback":
                        feedbackCount++;
                        break;
                }

                return true;
            }

            // Burde ikke være reachable, men skal være her ifølge syntax reglerne. Hellere lade en besked for meget end en for lidt slippe igennem.
            return true;
        }
    }
}
