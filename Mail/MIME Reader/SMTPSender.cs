using System;
using System.Text;
using System.Net;
using System.Net.Mime;
using System.Net.Mail;

namespace MIME_Reader
{
    public class SMTPSender
    {
        private SmtpClient Smtp = null;

        public SMTPSender(MIMEReader Reader)
        {
            Smtp = new SmtpClient();
        }
    }

}