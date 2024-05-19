namespace VideoCallApp.Models
{
    public class Message
    {
        public int MessageId {  get; set; }
        public string MessageContent {  get; set; }
        public int UserId {  get; set; }
        public User theUser {  get; set; }
    }
}
