using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VideoCallApp.Data;
using VideoCallApp.Models;

namespace VideoCallApp.Pages;

public class IndexModel : PageModel
{
    private readonly VideoCallApplicationDbContext theContext;
    public IndexModel(VideoCallApplicationDbContext theDbContext)
    {
        theContext = theDbContext;
    }
    [BindProperty]
    public User theUser {  get; set; }
    public List<User> Users { get; set; }
    public List<Image> Images { get; set; }
    public void OnGet(User user)
    {
        theUser = user;
        Users = theContext.Users.ToList();
        Images = theContext.Images.ToList();
    }
}