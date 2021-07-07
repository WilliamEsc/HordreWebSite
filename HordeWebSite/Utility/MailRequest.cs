using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HordeWebSite.Utility
{
    public class MailRequest
    {
        public MailRequest(string email, string v1, string v2)
        {
            ToEmail = email;
            Subject = v1;
            Body = v2;
        }

        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
