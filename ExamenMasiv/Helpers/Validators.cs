using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ExamenMasiv.Helpers
{
    public class Validators
    {
        public static bool IsValid(object instance, out ICollection<ValidationResult> results)
        {
            var context = new ValidationContext(instance, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(
                instance, context, results,
                validateAllProperties: true
            );
        }
        public static bool IsValid(object instance, out string message)
        {
            ICollection<ValidationResult> resultsValidation;
            if (IsValid(instance, out resultsValidation))
            {
                message = string.Empty;
                return true;
            }

            message = string.Join(Environment.NewLine, resultsValidation.Select(r => r.ErrorMessage));
            return false;
        }        
    }
}
