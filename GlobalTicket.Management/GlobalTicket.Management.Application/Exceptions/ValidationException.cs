namespace GlobalTicket.Management.Application.Exceptions
{
    using FluentValidation.Results;
    using System;
    using System.Collections.Generic;

    public class ValidationException : ApplicationException
    {
        public List<string> ValidationErrors { get; set; }
        public ValidationException(ValidationResult result) => result.Errors.ForEach(e => ValidationErrors.Add(e.ErrorMessage));
    }
}
