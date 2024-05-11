using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VideoCallApp.Pages
{
    public class PageToTalkModel : PageModel
    {
        [BindProperty]
        public int UsersId { get; set; }
        [BindProperty]
        public int TheOtherUserId { get; set; }
        public void OnGet(int otherUserId, int userId)
        {
            TheOtherUserId=otherUserId;
            UsersId=userId; 
        }
    }
}
