using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics.Metrics;
using VideoCallApp.Data;
using VideoCallApp.Models;

namespace VideoCallApp.Pages
{
    public class LogInModel : PageModel
    {
        private VideoCallApplicationDbContext _dbContext;
        public static int counterWrong = 0;
        public static bool banned = false;
        public static bool userGotWrong;
        public static DateTime timeBegin;
        public static DateTime timeEnd;
        public LogInModel(VideoCallApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public UserViewModel theViewModel { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!banned) {
                if (counterWrong < 6)
                {
                    userGotWrong = true;
                    var theUserList = _dbContext.Users.ToList();
                    for (int i = 0; i < theUserList.Count(); i++)
                    {
                        if (theUserList.ElementAt(i).Username == theViewModel.Username)
                        {
                            userGotWrong = false;
                            if (theUserList.ElementAt(i).Password == theViewModel.Password)
                            {
                                return RedirectToPage("VideoCallMenu",theUserList.ElementAt(i));
                            }
                            else
                            {
                                counterWrong++;
                                AuditLog.addInAuditLogWhenPasswordWrong();
                                break;
                            }
                        }   
                    }
                    if (userGotWrong)
                    {
                        counterWrong++;
                        AuditLog.addInAuditLogWhenUsernameWrong();
                    }
                    return RedirectToPage("Error");
                }
                else
                {
                    timeBegin = DateTime.Now;
                    banned = true;
                    counterWrong = 0;
                    return RedirectToPage("BanPage");
                }
            }
            else
            {
                timeEnd = DateTime.Now;
                TimeSpan interval = timeEnd.Subtract(timeBegin);
                if (interval.Minutes > 29)
                {
                    banned = false;
                }
                return RedirectToPage("BanPage");
            }
        }
    }
}
