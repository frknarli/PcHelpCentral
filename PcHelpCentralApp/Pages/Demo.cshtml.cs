using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PcHelpCentralApp.Pages
{
    public class DemoModel : PageModel
    {
        public String? EmployeeEmail => HttpContext?.Session?.GetString("name") ?? "";

        public void OnGet()
        {
        }

        public void OnPost([FromForm]string name) 
        {
            
            HttpContext.Session.SetString("name",name);
        }
    }
}
