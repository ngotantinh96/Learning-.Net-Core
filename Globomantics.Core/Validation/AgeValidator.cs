using System;
using System.ComponentModel.DataAnnotations;

namespace Globomantics.Core.Validation
{
    public class AgeValidator : ValidationAttribute
    {
        public int Age { get; set; }

        public override bool IsValid(object value)
        {
            if (value != null && DateTime.TryParse(value.ToString(), out DateTime dob))
            {
                if (dob.AddYears(Age) <= DateTime.Now)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
