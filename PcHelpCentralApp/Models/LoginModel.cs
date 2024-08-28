using Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace PcHelpCentralApp.Models
{
    public class LoginModel
    {
        
        private string? _returnUrl;
        
        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress(ErrorMessage ="Email cannot be written like this.")]
        public string? Email { get; set; }
        
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; set; }

        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                    return "/";
                else 
                    return _returnUrl;
            }
            set { _returnUrl = value; }
        }
    }
}
