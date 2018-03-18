using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eksempel_1.Services 
{
    public class HardcodedMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hardcoded message from a service.";
        }
    }
}
