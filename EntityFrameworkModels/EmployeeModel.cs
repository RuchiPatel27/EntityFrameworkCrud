using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkModels
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="please enter your firstname")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "please enter your lastname")]
        public string LastName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "please enter your emailid")]
        public string Email { get; set; }
        public int? AddressId { get; set; }
        [Required(ErrorMessage = "please enter your Code")]
        public string Code { get; set; }
        public AddressModel Address { get; set; }
    }
}
