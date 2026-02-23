using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.Dtos;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not DateTime dt)
            return new ValidationResult("Invalid date.");

        if (dt < DateTime.Now)
            return new ValidationResult("Date must not be in the past.");

        return ValidationResult.Success;
    }
}