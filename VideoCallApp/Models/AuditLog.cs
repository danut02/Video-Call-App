namespace VideoCallApp.Models
{
    public class AuditLog
    {
        private static List<string> auditLog = new List<string>();
        public static List<string> getAuditLog() { return auditLog; }
        public static void addInAuditLogWhenUsernameWrong()
        {
            getAuditLog().Add("Username it doesn't exist.Try again please. " + DateTime.Now);
        }
        public static void addInAuditLogWhenPasswordWrong()
        {
            getAuditLog().Add("Password is wrong.Try again please. " + DateTime.Now);
        }
        public static void addWrongPasswordSignUp()
        {
            getAuditLog().Add("Password is written wrong while signing up. " + DateTime.Now);
        }
        public static void addSameEmailError()
        {
            getAuditLog().Add("There is an existing email. " + DateTime.Now);
        }
    }
}
