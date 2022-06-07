using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Data.Requests
{
    public class ActivateAccountRequest
    {
        [Required]
        public string ActivationCode { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
