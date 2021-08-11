using System.ComponentModel.DataAnnotations;

namespace UserBackEnd.UserApi.Model
{
    public class UserModelView
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public short IdentificationTypeId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Email { get; set; }
    }

    /// <summary>
    /// Form Create User
    /// </summary>
    public class UserCreateModelView
    {
        /// <summary>
        /// Name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Last Name
        /// </summary>
        [Required]
        public string LastName { get; set; }
        /// <summary>
        /// Identification type
        /// </summary>
        [Required]
        public short IdentificationTypeId { get; set; }
        /// <summary>
        /// Identification Number (Without characters)
        /// </summary>
        [Required]
        [RegularExpression("([0-9]+)", ErrorMessage = "Characters are not allowed.")]
        [MinLength(1), MaxLength(20)]
        public string IdentificationNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Password (At least 1 numeric character)
        /// </summary>
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "The password must contain minimum eight characters, at least one letter, one number and one special character")]
        public string Password { get; set; }
    }
}