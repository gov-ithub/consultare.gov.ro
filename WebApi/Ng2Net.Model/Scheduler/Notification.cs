namespace Ng2Net.Model.Scheduler
{
    using System;    
    using System.ComponentModel.DataAnnotations;   
    using System.Net.Mail;    

    public class Notification : BaseEntity
    {
        public Notification()
        {            
            this.Timestamp = DateTime.Now;
            this.Status = "NEW";
        }

        [Required]
        [StringLength(255)]
        public string From { get; set; }

        [StringLength(255)]
        public string To { get; set; }

        [StringLength(255)]
        public string Cc { get; set; }

        [StringLength(255)]
        public string Bcc { get; set; }

        [StringLength(1000)]
        public string Subject { get; set; }

        public string Body { get; set; }

        public DateTime Timestamp { get; set; }

        [StringLength(255)]
        public string Status { get; set; }

        public DateTime? DateProcessed { get; set; }

        public int Counter { get; set; }

        public string Error { get; set; }

        public string Attachments { get; set; }


        public MailMessage ToMailMessage()
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(this.From);
            msg.To.Add(this.To);

            if (!string.IsNullOrEmpty(this.Cc))
                msg.CC.Add(this.Cc);

            if (!string.IsNullOrEmpty(this.Cc))
                msg.Bcc.Add(this.Bcc);

            msg.Subject = this.Subject;
            msg.Body = this.Body;
            msg.IsBodyHtml = true;
            if (!string.IsNullOrEmpty(this.Attachments))
            {
                string[] arrAttachments = Attachments.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                foreach (string fileName in arrAttachments)
                {
                    msg.Attachments.Add(new Attachment(fileName));
                }
            }

            return msg;
        }

    }
}