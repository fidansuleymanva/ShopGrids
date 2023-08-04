namespace ShopGrids.ViewModel.Member
{
    public class MemberRegisterViewModel
    {

        //[Required]
        //[StringLength(maximumLength: 100, ErrorMessage = "FullName size incorrent")]
        //public string FullName { get; set; }

        //[Required]
        //[StringLength(maximumLength: 50, ErrorMessage = "FullName size incorrent")]
        //public string UserName { get; set; }
        //[Required]
        //[StringLength(maximumLength: 50, ErrorMessage = "FullName size incorrent")]
        //public string Email { get; set; }
        //[Required]
        //[StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "FullName size incorrent"), DataType(DataType.Password)]
        //public string Password { get; set; }
        //[Required]
        //[StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "FullName size incorrent"), DataType(DataType.Password)]
        //[Compare(nameof(Password))]
        //public string ConfigurePassword { get; set; }

       
            [Required(ErrorMessage = "FullName is required.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "UserName is required.")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Confirm Password is required.")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        

    }

}

