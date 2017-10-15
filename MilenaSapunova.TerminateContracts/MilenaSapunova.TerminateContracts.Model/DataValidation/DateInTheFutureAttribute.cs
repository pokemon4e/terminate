using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MilenaSapunova.TerminateContracts.Model.DataValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class DateInTheFutureAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var futureDate = value as DateTime?;
            var memberNames = new List<string>() { context.MemberName };

            if (futureDate != null)
            {
                if (!(futureDate.Value.Date > DateTime.UtcNow.Date))
                {
                    return new ValidationResult("Date must be in the future.", memberNames);
                }
            }

            return ValidationResult.Success;
        }
    }
}
