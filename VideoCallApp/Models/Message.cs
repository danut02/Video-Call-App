using System.ComponentModel.DataAnnotations;
using System;
namespace VideoCallApp.Models
{
    public class Message
    {
        public Message(int ID,string text)
        {

            MsgID = ID;
            MsgText = text;
        }
        [Key]
        public int MsgID { get; set; }
        public string MsgText { get; set; }
        
        public int UserID { get; set; }
       
        public DateTime MsgSendDate { get; set; }
        public DateTime MsgDeleteDate { get; set; }
        public int NumberOfMsg {get;set;}
        public User user { get; set; }
        
    }


}
