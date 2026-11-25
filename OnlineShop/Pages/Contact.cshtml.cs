using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OnlineShop.Pages;

public class ContactModel : PageModel
{
    public string Message { get; set; }

    public void OnGet()
    {
        Message = "";
    }

    public void OnPost(string Name, string Email, string Message)
    {
        // Handle the form submission
        this.Message = $"Thanks {Name}! We received your message and will reply to {Email} soon.";

        // In a real app, you'd save this to a database or send an email
    }
}

