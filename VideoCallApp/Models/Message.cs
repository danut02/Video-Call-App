using System.ComponentModel.DataAnnotations;

namespace VideoCallApp.Models
{
    public class Message
    {
        [Key]
        public string MsgID { get; set; }
        public string MsgText { get; set; }
        
        public int UserID { get; set; }
        public string Username { get; set; }
        public DateTime MsgSendDate { get; set; }
        public DateTime MsgDeleteDate { get; set; }
        public int NumberOfMsg {get;set;}
        public User user { get; set; }
    }


}
