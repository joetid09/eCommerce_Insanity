using System;
using System.ComponentModel.DataAnnotations;

namespace eCommerce_Insanity.DTOs.User;

public class CreateUserDTO
{
    [StringLength(15, MinimumLength = 3)]
    public required string UserName { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    [StringLength(15, MinimumLength = 6)]
    public required string Password { get; set; }

    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public required string ConfirmPassword { get; set; }
}
