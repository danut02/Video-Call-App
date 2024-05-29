using Microsoft.AspNetCore.Mvc;
using VideoCallApp.Models;
using VideoCallApp.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;

namespace VideoCallApp.Pages
{
    public class PageToTalkModel : PageModel
    {
        private readonly VideoCallApplicationDbContext theDatabase;
        public PageToTalkModel(VideoCallApplicationDbContext theContext)
        {
            theDatabase = theContext;
        }
        [BindProperty]
        public int UsersId { get; set; }
        [BindProperty]
        public int TheOtherUserId { get; set; }
        [BindProperty]
        public User theUser { get; set; }
        public void OnGet()
        {
        }
    }
}