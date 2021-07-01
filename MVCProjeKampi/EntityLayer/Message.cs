using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Message
    {
        [Key]
        public int MessageID { get; set; }
        [StringLength(50)]
        public string SenderMail { get; set; }
        [StringLength(50)]
        public string ReceiverMail { get; set; }
        [StringLength(100)]
        public string Subject { get; set; }
        //nvarchar max olması için bir şey yazmadık.
        public string MessageContent { get; set; }
        public bool IsDraft { get; set; }
        public DateTime MessageDate { get; set; }
    }
}
