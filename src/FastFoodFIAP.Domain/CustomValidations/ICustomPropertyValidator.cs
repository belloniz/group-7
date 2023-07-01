﻿using FluentValidation.Validators;

namespace FastFoodFIAP.Domain.CustomValidations
{
    public interface ICustomPropertyValidator
    {
        interface ICustomPropertyValidator : IPropertyValidator
        {
        }
    }
}
