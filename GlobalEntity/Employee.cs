using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GlobalEntity
{
    public class tblEmployee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10), MinLength(10)]
        public string Mobile { get; set; }
    }
    public class tblEmployeeLogin
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailId { get; set; }
        [Required]
        public string Password { get; set; }
    }
    public class tblUser
    {
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}