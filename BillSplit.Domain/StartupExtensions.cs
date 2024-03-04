﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BillSplit.Domain.ExceptionHandlers;

namespace BillSplit.Domain;

public static class StartupExtensions
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddExceptionHandler<DefaultExceptionHandler>();
        return services;
    }
}